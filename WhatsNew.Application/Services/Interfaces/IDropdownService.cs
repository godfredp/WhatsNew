using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsNew.Application.DTOs;

namespace WhatsNew.Application.Services.Interfaces
{
	public interface IDropdownService
	{
		Task<List<TopicTagDTO>> GetTopicTagsAsync();
		Task<List<RoleTagDTO>> GetRoleTagsAsync();
		Task<List<UserDTO>> GetUsersAsync();
	}
}
