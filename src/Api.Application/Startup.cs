using System;
using AutoMapper;
using Microsoft.OpenApi.Models;
using Api.CrossCutting.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Api.CrossCutting.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Application
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
            ConfigureRepository.ConfigureDependenciesRepository(services);
            ConfigureService.ConfigureDependenciesService(services);

            var config = new AutoMapper.MapperConfiguration(cfg =>
           {
               cfg.AddProfile(new DTOToModelProfile());
               cfg.AddProfile(new EntityToDTOProfile());
               cfg.AddProfile(new EntityToModelProfile());
           });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Market Api",
                    Version = "v1",
                    Description = "Market Api with architecture DDD",
                    Contact = new OpenApiContact
                    {
                        Name = "Roberta Suélen Rodrigues Alves",
                        Email = "rodriguesalves.roberta@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/roberta-su%C3%A9len-rodrigues-alves-223733116")
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Application v1"));
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
