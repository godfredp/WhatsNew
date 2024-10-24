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
	public class DropdownService : IDropdownService
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;

		public DropdownService(ApplicationDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<List<RoleTagDTO>> GetRoleTagsAsync()
		{
			var roleTags = await context.RoleTags.Include(x => x.RoleGroup).ToListAsync();

			return mapper.Map<List<RoleTagDTO>>(roleTags);
		}

		public async Task<List<TopicTagDTO>> GetTopicTagsAsync()
		{
			var topicTags = await context.TopicTags.Include(x => x.TopicGroup).ToListAsync();

			return mapper.Map<List<TopicTagDTO>>(topicTags);
		}

		public async Task<List<UserDTO>> GetUsersAsync()
		{
			var users = await context.Users.Include(x => x.RoleTag).ToListAsync();

			return mapper.Map<List<UserDTO>>(users);
		}
	}
}
