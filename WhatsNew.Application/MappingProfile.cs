using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WhatsNew.Application.DTOs;
using WhatsNew.Application.Models;

namespace WhatsNew.Application
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Feature, FeatureDTO>().ReverseMap();
			CreateMap<Announcement, AnnouncementDTO>().ReverseMap();
			CreateMap<SubFeature, SubFeatureDTO>().ReverseMap();
			CreateMap<FeatureGuide, FeatureGuideDTO>().ReverseMap();
			//CreateMap<FeatureSteps, FeatureStepsDTO>().ReverseMap();
			//CreateMap<RoleTag, RoleTagDTO>().ReverseMap();
			//CreateMap<FeatureSteps, FeatureStepsDTO>().ReverseMap();
			//CreateMap<RoleGroup, RoleGroupDTO>().ReverseMap();

		}
	}
}
