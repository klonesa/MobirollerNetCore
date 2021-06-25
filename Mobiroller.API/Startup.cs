using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Mobiroller.API.Extensions;
using Mobiroller.Core.DependencyResolvers;
using Mobiroller.Core.Extensions;
using Mobiroller.Core.Utilities.IoC;

namespace Mobiroller.API
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
            //Request Localization Options
            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en-US"),
                        new CultureInfo("it-IT"),
                        new CultureInfo("tr-TR")
                    };

                    options.DefaultRequestCulture = new RequestCulture(culture: "tr-TR", uiCulture: "tr-TR");
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                    options.RequestCultureProviders = new[] { new RouteDataRequestCultureProvider { IndexOfCulture = 1, IndexofUICulture = 1 } };
                });

            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("culture", typeof(LanguageRouteConstraint));
            });

            services.AddControllers();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Token:Issuer"],
                    ValidAudience = Configuration["Token:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"])),
                    ClockSkew = TimeSpan.Zero
                };

            });

            //Farklý modül kullanýmý için bir ICoreModule interfacesi oluþturarak startup'ý baðýmlýlýktan kurtarmaktadýr.
            services.AddDependencyResolvers(new ICoreModule[] { new CoreModule(), });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //Request Localization
            var localizeOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizeOptions.Value);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("default", "{culture:culture}/api/{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
