using System;
using Wheelzy.Infrastructure;
using Wheelzy.Services;
using Wheelzy.Services.Interfaces;

namespace Wheelzy.API.Configuration
{
	public static class Services
	{
		public static IServiceCollection RegisterServices(this IServiceCollection  services)
		{
			services.AddScoped<ISellsService, SellsService>();

			return services;
		}
	}
}

