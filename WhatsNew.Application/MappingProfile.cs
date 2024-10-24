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
			CreateMap<RoleTag, RoleTagDTO>()
				.ForMember(p => p.RoleGroupName, opt => opt.MapFrom(e => e.RoleGroup.Name));
			CreateMap<User, UserDTO>()
				.ForMember(p => p.RoleTagName, opt => opt.MapFrom(e => e.RoleTag.Name));
			CreateMap<TopicTag, TopicTagDTO>()
				.ForMember(p => p.TopicGroupName, opt => opt.MapFrom(e => e.TopicGroup.Name));

		}
	}
}
