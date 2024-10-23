using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WhatsNew.Application.Services;
using WhatsNew.Application.Services.Interfaces;

namespace WhatsNew.Application
{
	public static class ServiceExtensions
	{
		public static void AddApplicationLayer(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(MappingProfile));
			services.AddScoped<IAnnouncementService, AnnouncementService>();
			services.AddScoped<IFeatureService, FeatureService>();
		}
	}
}
