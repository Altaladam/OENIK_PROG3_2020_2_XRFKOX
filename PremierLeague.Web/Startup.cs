// <copyright file="Startup.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Web
{
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using PremierLeague.Data;
    using PremierLeague.Logic;
    using PremierLeague.Repository;
    using PremierLeague.Web.Models;

    /// <summary>
    /// The startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">An instance of the IConfiguration interface.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets an instance of the IConfiguration interface.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// The method that configures the services.
        /// </summary>
        /// <param name="services">A collection of services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddScoped<IReadLogic, ReadLogic>();
            services.AddScoped<IModifyLogic, ModifyLogic>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<DbContext, PLContext>();
            services.AddSingleton<IMapper>(provider => MapperFactory.CreateMapper());
        }

        /// <summary>
        /// The method that configures the application.
        /// </summary>
        /// <param name="app">An instance of an ApplicationBuilder.</param>
        /// <param name="env">An instance of a WebHostEnvironment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
