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
			newSubFeature.VideoUrl = subFeature.VideoUrl;
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

		public async Task<IEnumerable<Feature>> FilterFeatures(int roleTagId = 0, int topicTagId = 0)
		{
			var features = await context.Features
						  .Where(x => x.RoleTagId == roleTagId && x.TopicTagId == topicTagId).ToListAsync();

			return features;
		}

		public async Task<FeatureDTO> GetFeatureAsync(int id)
		{
			var result = await context.Features.Where(x => x.Id == id).FirstOrDefaultAsync();

			if (result == null) return null;

			var mappedResult = mapper.Map<FeatureDTO>(result);

			mappedResult.SubFeatures = await GetSubFeaturesByFeatureId(result.Id);
			mappedResult.FeatureGuides = await GetFeatureGuidesByFeatureId(result.Id);

			return mappedResult;
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
				return null;
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
						.OrderByDescending(x => x.CreatedDate).FirstOrDefaultAsync();

			if(result == null) return null;

			var mappedResult = mapper.Map<FeatureDTO>(result);

			mappedResult.SubFeatures = await GetSubFeaturesByFeatureId(result.Id);
			mappedResult.FeatureGuides = await GetFeatureGuidesByFeatureId(result.Id );

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
	}
}
