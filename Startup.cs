using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreWebTutorial
{
    public class Startup
    {
		public IConfiguration Configuration { get; set; }
		//Creating the constructor to allow injecting the configuration into the build.
		//You do not need to create the parametrer of the construct. The system will create one and pass it as parameter.
		public Startup(IConfiguration config)
		{
			Configuration = config;
		}
		
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
			//Adding MVC to the service for deploy razor pages.
			services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

			//Setup the MVC. This will use the defaults settings for a MVC project.
			//The default page should be named Index.cshtml and should be found at the Pages folder at root of the project.
			app.UseMvc();

            app.Run(async (context) =>
            {
				//This is the only line that came with the default project. A single line web app.
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
