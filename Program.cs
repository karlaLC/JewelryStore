using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStore
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
			//.ConfigureAppConfiguration(SetupConfiguration)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});


		//TODO: would use this if we wanted to override the appsettings.json file with a new "config.json" file
		//(these files are .Net Core's equivalent of the Web.config files in .NET)

		//private static void SetupConfiguration(HostBuilderContext ctx, IConfigurationBuilder builder)
		//{
		//	//Removing the default configuration options
		//	builder.Sources.Clear();
			
		//	builder.AddJsonFile("config.json", false, true)
		//		.AddEnvironmentVariables();
		//}
	}
}
