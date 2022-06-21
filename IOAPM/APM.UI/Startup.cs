using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APM.Repository.Context;
using APM.Repository;
using APM.Repository.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;


namespace APM.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddSession();

            services.Configure<CookiePolicyOptions>(options =>
            {
               
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
            });


            var SecretKey = Encoding.ASCII.GetBytes("YourKey-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv");

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(token =>
            {
                token.RequireHttpsMetadata = false;
                token.SaveToken = true;
                token.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(SecretKey),
                    ValidateIssuer = true,
                    ValidIssuer = "http://localhost:45092/",
                    ValidateAudience = true,
                    ValidAudience = "http://localhost:45092/",
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddScoped<DbContext, APMDbContext>();
            services.AddDbContext<APMDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("APMDbConnectionString"));
                
            });
  
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenProvider, TokenProvider>();
            services.AddScoped<IIndexRepository, IndexRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectTypeRepository, ProjectTypeRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IPublicHolidays, PublicHolidays>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<ISendEmail, SendEmail>();//AddTransient
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IPriorityRepository, PriorityRepository>();
            services.AddScoped<ITitleRepository, TitleRepository>();
            services.AddScoped<ILevelRepository, LevelRepository>();


        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
              
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.UseHsts();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRequestLocalization();
            app.UseSession();


            app.Use(async (context, next) =>
            {
                var JWToken = context.Session.GetString("JWToken");
                if (!string.IsNullOrEmpty(JWToken))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
                }
                await next();
            });

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
