using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WhatsNew.Application.DTOs;
using WhatsNew.Application.Models;
using WhatsNew.Application.Services.Interfaces;

namespace WhatsNew.Application.Services
{
	public class FeatureService : IFeatureService
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;

		public FeatureService(ApplicationDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<Feature> CreateFeatureAsync(FeatureDTO feature)
		{
			var newFeature = new Feature();
			newFeature.RoleTagId = feature.RoleTagId;
			newFeature.TopicTagId = feature.TopicTagId;
			newFeature.AnnouncementId = feature.AnnouncementId;
			newFeature.IsMajor = feature.IsMajor;
			newFeature.CreatedDate = DateTime.Now;
			newFeature.Author = feature.Author;

			var result = await context.Features.AddAsync(newFeature);
			await context.SaveChangesAsync();

			newFeature = result.Entity;

			if (feature.SubFeatures != null && feature.SubFeatures.Count > 0)
			{
				var listSubfeature = new List<SubFeature>();
				foreach(var subFeature in feature.SubFeatures)
				{
					var output = await CreateSubFeatureAsync(subFeature, result.Entity.Id);
					listSubfeature.Add(output);
				}

				newFeature.SubFeatures = listSubfeature.OrderBy(x=> x.Id).ToList();
			}

			if(feature.FeatureGuides != null && feature.FeatureGuides.Count > 0)
			{
				var listFeatureGuide = new List<FeatureGuide>();
				foreach(var featureGuide in feature.FeatureGuides)
				{
					var output = await CreateFeatureGuideAsync(featureGuide, result.Entity.Id);
					listFeatureGuide.Add(output);
				}

				newFeature.FeatureGuides = listFeatureGuide;
			}
			
			return newFeature;
		}

		private async Task<SubFeature> CreateSubFeatureAsync(SubFeatureDTO subFeature, int featureId)
		{
			var newSubFeature = new SubFeature();
			newSubFeature.FeatureId = featureId;
			newSubFeature.Text = subFeature.Text;

			var arcadeUrl = "https://app.arcade.software/share/";
			if (subFeature.VideoUrl != null && subFeature.VideoUrl.Contains(arcadeUrl))
			{
				var updatedUrl = "https://demo.arcade.software/";

				newSubFeature.VideoUrl = subFeature.VideoUrl.Replace(arcadeUrl, updatedUrl);
			}
			
			context.SubFeatures.Add(newSubFeature);
			await context.SaveChangesAsync();
			return newSubFeature;
		}

		private async Task<FeatureGuide> CreateFeatureGuideAsync(FeatureGuideDTO featureGuide, int featureId)
		{
			var newFeatureGuide = new FeatureGuide();
			newFeatureGuide.FeatureId = featureId;
			newFeatureGuide.Steps = featureGuide.Steps;

			context.FeatureGuides.Add(newFeatureGuide);
			await context.SaveChangesAsync();
			return newFeatureGuide;
		}

		public async Task<bool> DeleteFeatureAsync(int id)
		{
			var feature = await context.Features.FindAsync(id);
			if (feature == null)
			{
				return false;
			}
			context.Features.Remove(feature);
			await context.SaveChangesAsync();
			return true;
		}

		public async Task<IEnumerable<FeatureDTO>> FilterFeatures(int roleTagId = 0, int topicTagId = 0)
		{
			var features = await context.Features
				.Where(x => (x.RoleTagId == roleTagId || roleTagId == 0) && (x.TopicTagId == topicTagId || topicTagId == 0))
				.ToListAsync();

			var featureList = new List<FeatureDTO>();
			foreach(var feature in features)
			{
				var mappedFeature = mapper.Map<FeatureDTO>(feature);

				mappedFeature.SubFeatures = await GetSubFeaturesByFeatureId(feature.Id);
				mappedFeature.FeatureGuides = await GetFeatureGuidesByFeatureId(feature.Id);

				featureList.Add(mappedFeature);
			}

			return featureList;
		}

		public async Task<FeatureDTO> GetFeatureAsync(int id)
		{
			var result = await context.Features.Where(x => x.Id == id).FirstOrDefaultAsync();

			if (result == null)
			{
				throw new Exception("Feature not found");
			};

			var mappedResult = mapper.Map<FeatureDTO>(result);

			mappedResult.SubFeatures = await GetSubFeaturesByFeatureId(result.Id);
			mappedResult.FeatureGuides = await GetFeatureGuidesByFeatureId(result.Id);

			mappedResult.RoleTagName = await GetRoleTagName(result.RoleTagId);
			mappedResult.TopicTagName = await GetTopicTagName(result.TopicTagId);

			return mappedResult;
		}

		private async Task<string> GetRoleTagName(int roleTagId)
		{
			return await context.RoleTags.Where(x => x.Id == roleTagId).Select(x => x.Name).FirstOrDefaultAsync();
		}

		private async Task<string> GetTopicTagName(int topicTagId)
		{
			return await context.TopicTags.Where(x => x.Id == topicTagId).Select(x => x.Name).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Feature>> GetFeaturesByAnnouncementAsync(int announcementId)
		{
			return await context.Features.Where(x => x.AnnouncementId == announcementId).ToListAsync();
		}

		public async Task<Feature> UpdateFeatureAsync(FeatureDTO feature)
		{
			var existingFeature = await context.Features
										.Include(x => x.SubFeatures)
										.Include(x => x.FeatureGuides)
										.Where(x => x.Id == feature.Id)
										.FirstOrDefaultAsync();

			if (existingFeature == null)
			{
				throw new Exception("Feature not found");
			}

			existingFeature.RoleTagId = feature.RoleTagId;
			existingFeature.TopicTagId = feature.TopicTagId;
			existingFeature.AnnouncementId = feature.AnnouncementId;
			existingFeature.IsMajor = feature.IsMajor;
			existingFeature.UpdatedDate = DateTime.Now;
			existingFeature.Author = feature.Author;

			if (feature.SubFeatures != null)
			{
				var existingSubs = existingFeature.SubFeatures;
				context.RemoveRange(existingSubs);

				existingFeature.SubFeatures = mapper.Map<List<SubFeature>>(feature.SubFeatures).ToList(); //feature.SubFeatures;
				context.UpdateRange(existingFeature.SubFeatures);
			}

			if (feature.FeatureGuides != null)
			{
				var existingGuides = existingFeature.FeatureGuides;
				context.RemoveRange(existingGuides);

				existingFeature.FeatureGuides = mapper.Map<List<FeatureGuide>>(feature.FeatureGuides).ToList(); //feature.FeatureGuides;
				context.UpdateRange(existingFeature.FeatureGuides);
			}

			context.Update(existingFeature);

			await context.SaveChangesAsync();
			return existingFeature;
		}

		public async Task<FeatureDTO> GetLatestFeatureAsync()
		{
			var result = await context.Features
						.OrderByDescending(x => x.Id).FirstOrDefaultAsync();

			if(result == null) return null;

			var mappedResult = await GetFeatureAsync(result.Id);

			return mappedResult;
		}

		private async Task<List<SubFeatureDTO>> GetSubFeaturesByFeatureId(int featureId)
		{
			var subFeatures = await context.SubFeatures.Where(x => x.FeatureId == featureId).ToListAsync();
			return mapper.Map<List<SubFeatureDTO>>(subFeatures);
		}

		private async Task<List<FeatureGuideDTO>> GetFeatureGuidesByFeatureId(int featureId)
		{
			var featureGuides = await context.FeatureGuides.Where(x => x.FeatureId == featureId).ToListAsync();
			return mapper.Map<List<FeatureGuideDTO>>(featureGuides);
		}

		public async Task<List<FeatureDTO>> GetLatestFeatureByUserIdAsync(int userId)
		{
			var user = await context.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
			if (user == null)
			{
				throw new Exception("User not found");
			};

			var result = await context.Features
						.Where(x => x.RoleTagId == user.RoleTagId)
						.OrderByDescending(x => x.Id).ToListAsync();

			if (result.Count == 0)
			{
				throw new Exception("No annoucement for user");
			};

			var listOfFeatures = new List<FeatureDTO>();
			foreach (var feature in result)
			{
				var mappedResult = await GetFeatureAsync(feature.Id);

				listOfFeatures.Add(mappedResult);
			}
			
			return listOfFeatures;
		}
	}
}
