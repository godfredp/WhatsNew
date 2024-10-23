using Microsoft.AspNetCore.Mvc;
using WhatsNew.Application.DTOs;
using WhatsNew.Application.Models;
using WhatsNew.Application.Services.Interfaces;

namespace WhatsNew.Controllers
{
	[ApiController]
	[Route("api/v1/features")]
	public class FeatureController : ControllerBase
	{
		private readonly IFeatureService featureService;

		public FeatureController(IFeatureService featureService)
		{
			this.featureService = featureService;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var result = await featureService.GetFeatureAsync(id);
			return Ok(result);
		}

		[HttpPut("update")]
		public async Task<IActionResult> Update( [FromBody] FeatureDTO feature)
		{
			var result = await featureService.UpdateFeatureAsync(feature);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] FeatureDTO feature)
		{
			var result = await featureService.CreateFeatureAsync(feature);
			return Ok(result);
		}

		[HttpGet("latest")]
		public async Task<IActionResult> GetLatest()
		{
			var result = await featureService.GetLatestFeatureAsync();
			return Ok(result);
		}

	}
}
