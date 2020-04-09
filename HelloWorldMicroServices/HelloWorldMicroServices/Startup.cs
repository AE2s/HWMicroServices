using System;
using HelloWorldMicroServices.Domain;
using HelloWorldMicroServices.Domain.Commands;
using HelloWorldMicroServices.Domain.Queries;
using HelloWorldMicroServices.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HelloWorldMicroServices.Application
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
            services.AddCors(c =>
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()));
            //services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowOrigin", options => options.WithOrigins("https://localhost:44342"));
            //});

            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(Configuration["Swagger:Version"], new OpenApiInfo
                {
                    Title = Configuration["Swagger:Title"],
                    Version = Configuration["Swagger:Version"],
                    Description = Configuration["Swagger:Description"]
                });
            });

            services.AddSingleton<IArticleRepository, ArticleRepository>();
            services.AddScoped<ICommandService, CommandService>();
            services.AddScoped<IQueryService, QueryService>();

            //services.AddMediatR(typeof(Startup));
            //because is not in the same assembly
            var assembly = AppDomain.CurrentDomain.Load("HelloWorldMicroServices.Domain");
            services.AddMediatR(assembly);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin());
            //app.UseCors(options => options.WithOrigins("https://localhost:44342"));

            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{Configuration["Swagger:Title"]} {Configuration["Swagger:Version"]}");
                });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
