using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rise.Assessment.Api.MapperConfigurations;
using Rise.Assessment.Business.Services;
using Rise.Assessment.Common.Filters;
using Rise.Assessment.Common.MapperConfigurations;
using Rise.Assessment.Database;
using Rise.Assessment.Database.Repositories;
using Rise.Assessment.Log4netDatabase;

namespace Rise.Assessment.Api
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
            services.AddControllers(config =>
            {
                config.Filters.Add(new ErrorHandlingFilter());
            });
            services.AddDbContext<RiseDbContext>();
            services.AddDbContext<Log4netContext>();

            services.AddScoped<PersonService>();
            services.AddScoped<PersonRepository>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PersonMapProfile());
                mc.AddProfile(new ContactInfoMapProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
