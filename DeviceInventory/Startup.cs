using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceInventory.Data;
using DeviceInventory.Models;
using DeviceInventory.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace DeviceInventory
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
            services.AddDbContext<ApplicationDbContext>(
            option => option.UseSqlServer(Configuration.GetConnectionString("DeviceInventoryConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>(
                options =>
                {
                    options.Stores.MaxLengthForKeys = 128;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                }).AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(option =>
            {
                option.SaveToken = true;
                option.RequireHttpsMetadata = true;
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = Configuration["Jwt:Site"],
                    ValidAudience = Configuration["Jwt:Site"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SigningKey"]))

                };
            });

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IProfileRepository, ProfileRepository>();
            services.AddSingleton<ISubsidiaryRepository, SubsidiaryRepository>();
            services.AddSingleton<IEmployeeTypeRepository, EmployeeTypeRepository>();
            //Device
            services.AddSingleton<IDeviceColorRepository, DeviceColorRepository>();
            services.AddSingleton<IDeviceTypeRepository, DeviceTypeRepository>();
            services.AddSingleton<IDevicePropertyTypeRepository, DevicePropertyTypeRepository>();
            services.AddSingleton<IDeviceModelRepository, DeviceModelRepository>();
            services.AddSingleton<IDeviceRepository, DeviceRepository>();
            services.AddSingleton<IVisitorRepository, VisitorRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            ISubsidiaryRepository subsidiary,
            IEmployeeTypeRepository employeeType,
            IDevicePropertyTypeRepository devicePropertyType,
            IDeviceColorRepository deviceColor,
            IDeviceModelRepository deviceModel,
            IDeviceTypeRepository deviceType
            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            app.UseStaticFiles();

            DataInitializer.SeedData(userManager, roleManager,subsidiary,employeeType, devicePropertyType, deviceColor, deviceModel, deviceType);

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvcWithDefaultRoute();
        }
    }
}
