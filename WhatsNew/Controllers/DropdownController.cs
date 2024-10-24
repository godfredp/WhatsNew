using Microsoft.AspNetCore.Mvc;
using WhatsNew.Application.Services;
using WhatsNew.Application.Services.Interfaces;

namespace WhatsNew.Controllers
{
	[ApiController]
	[Route("api/v1/dropdown")]
	public class DropdownController : ControllerBase
	{
		private readonly IDropdownService dropdownService;

		public DropdownController(IDropdownService dropdownService)
		{
			this.dropdownService = dropdownService;
		}

		[HttpGet("users")]
		public async Task<IActionResult> GetUsers()
		{
			var result = await dropdownService.GetUsersAsync();
			return Ok(result);
		}

		[HttpGet("topic-tags")]
		public async Task<IActionResult> GetTopicTags()
		{
			var result = await dropdownService.GetTopicTagsAsync();
			return Ok(result);
		}

		[HttpGet("role-tags")]
		public async Task<IActionResult> GetRoleTags()
		{
			var result = await dropdownService.GetRoleTagsAsync();
			return Ok(result);
		}
	}
}
