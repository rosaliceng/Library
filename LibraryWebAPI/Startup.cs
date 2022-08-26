using LibraryWebAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LibraryWebAPI
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
            services.AddDbContext<LibraryContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default"))
                );
            services.AddControllers()
                    .AddNewtonsoftJson(
                       opt => opt.SerializerSettings.ReferenceLoopHandling =
                       Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IRepository, Repository>();

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            })
                .AddApiVersioning(options => 
                {
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.ReportApiVersions = true;   
                });

            var apiProviderDescription = services.BuildServiceProvider()
                                                 .GetService<IApiVersionDescriptionProvider>();  
            services.AddSwaggerGen(options =>{

                foreach (var description in apiProviderDescription.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                   description.GroupName,
                   new Microsoft.OpenApi.Models.OpenApiInfo()
                   {
                       Title = "Library Web API",
                       Version = description.ApiVersion.ToString(),
                   }
                   );
                }

               
                var xmlCommentsFiles = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFiles);

                options.IncludeXmlComments(xmlCommentsFullPath);
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IWebHostEnvironment env,
                              IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger()
               .UseSwaggerUI(options => {

                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                   {
                       options.SwaggerEndpoint(
                           $"/swagger/{description.GroupName}/swagger.json",
                           description.GroupName.ToUpperInvariant()
                           );
                   }

                
                    options.RoutePrefix = "";
                });

           //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
