﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Text;
using UITOUX.Web.Service.DBConfiguration;
using UITOUX.Web.Service.Interfaces;
using UITOUX.Web.Service.Repository;

namespace UITOUX.Web.Service
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private static string contentRootPath;
        public Startup(IConfiguration configuration,
            IWebHostEnvironment env)
        {
            _configuration = configuration;
            contentRootPath = env.ContentRootPath;

        }
        public void ConfigureServices(IServiceCollection services)
        {
            var databasePath = Path.Combine(contentRootPath, "DBConfiguration", "uiux2024db.db");

            Console.WriteLine($"Database Path: {databasePath}");

            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlite($"Data Source={databasePath}"));


            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services.AddMvc().AddXmlSerializerFormatters();

            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBannerService, BannerService>();
            services.AddScoped<IBannerItemService, BannerItemService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IModelService, ModelService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UITOUX Service", Version = "v1" });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDBContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                    SeedData.Initialize(dbContext);
                }
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "UITOUX Service");
            });
        }
    }
}
