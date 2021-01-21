using AutoMapper;
using JewelryStore.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace JewelryStore
{
	public class Startup
	{
		private readonly IConfiguration _configuration; 

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//Context to connect to the db
			services.AddDbContext<JewelryStoreContext>( config => {
				config.UseSqlServer(_configuration.GetConnectionString("JewelryStoreConnectionString"));
			});

			services.AddScoped<IJewelryStoreRepository, JewelryStoreRepository>(); //To get our data through this repository; this repository is going to need the context

			services.AddAutoMapper(Assembly.GetExecutingAssembly()); //assembly/dll that holds the project itself

			services.AddControllers();

			services.AddMvc();
			  //.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
