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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestaurantsWeb.Entities;
using RestaurantsWeb.Repositories;
using AutoMapper;
using RestaurantsWeb.Models;
using FluentValidation.AspNetCore;
using FluentValidation;

namespace RestaurantsWeb
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
            services.AddDbContext<RestaurantContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("RestaurantDatabaseConnection")));

            services.AddTransient<IRestaurantRepository, RestaurantRepository>();

            services.AddTransient<IValidator<AddRestaurantRequest>, AddRestaurantRequestValidator>();
            services.AddTransient<IValidator<UpdateRestaurantRequest>, UpdateRestaurantRequestValidator>();

            services.AddAutoMapper();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
