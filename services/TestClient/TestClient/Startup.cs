using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TestClient.Camunda;
using TestClient.Extensions;

namespace TestClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.SetupConfiguration(Configuration);

            // services.AddSingleton<ICamundaClient, TestClient.Camunda.CamundaClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            var fileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "UI/testUserForm"));

            var defaultFileOptions = new DefaultFilesOptions();
            defaultFileOptions.DefaultFileNames.Clear();
            defaultFileOptions.DefaultFileNames.Add("index.html");
            defaultFileOptions.FileProvider = fileProvider;
            app.UseDefaultFiles(defaultFileOptions);

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = fileProvider
            });

            app.UseHttpsRedirection();

            // app.UseHsts();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            // var camunda = app.ApplicationServices.GetService<ICamundaClient>();

            // var camundaSettings = app.ApplicationServices.GetService<IOptions<Configuration.Camunda>>().Value;

            // var camunda = new CamundaClient(camundaSettings);
            // camunda.Run();
        }
    }
}