using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ModelLibrary;
using RestServiceInMemory.Context;

namespace RestServiceInMemory
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
            services.AddDbContext<CarContext>(opt => opt.UseInMemoryDatabase("Database"));
            services.AddControllers();

            services.AddSwaggerGen(c => c.SwaggerDoc("API", new OpenApiInfo
            {
                Title = "API",
                Version = "v1.0",
                Description = "An open API for " + nameof(Car),
                License = new OpenApiLicense()
                {
                    Name = "MIT",
                },
            }));
            services.AddCors(opt => opt.AddPolicy("AllowEverything",
                builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartHome API V1");
                c.RoutePrefix = "api/help";
            });

            app.UseRouting();
            app.UseCors("AllowEverything");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
