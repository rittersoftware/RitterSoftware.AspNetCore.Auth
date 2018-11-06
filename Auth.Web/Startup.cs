using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Auth.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Web
{
    public class Startup
    {

        private RequestLocalizationOptions localizationOptions;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Temporary user
            //TODO: Remove
            var users = new Dictionary<string, string> { { "jritter", "password" } };

            services.AddSingleton<IUserService>(new UserService(users));


            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                }).AddCookie(options =>
            {
                options.LoginPath = "/auth/signin";
                options.LogoutPath = "/auth/signout";
            });

            services.AddMvc(options =>
                {
                    options.Filters.Add(new RequireHttpsAttribute());
                    options.SslPort = 44316;
                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddControllersAsServices()
                .AddDataAnnotationsLocalization()
                .AddViewLocalization()
                .AddMvcLocalization();                


            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("es-MX")
            };

            localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            localizationOptions.RequestCultureProviders = new IRequestCultureProvider[]
            {
                new RouteDataRequestCultureProvider() { Options = localizationOptions }
            };

            services.AddSingleton(localizationOptions);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseRouter(routes =>
            {
                routes.MapMiddlewareRoute("{culture=en-US}/{*mvcRoute}", subApp =>
                {
                    subApp.UseRequestLocalization(localizationOptions);

                    subApp.UseMvc(mvcRoutes =>
                    {
                        mvcRoutes.MapRoute(
                            name: "default",
                            template: "{culture=en-US}/{controller=Home}/{action=Index}/{id?}");
                    });
                });
            });

            app.UseHttpsRedirection();
            app.UseRewriter(new RewriteOptions().AddRedirectToHttps(301, 44316));
            app.UseStaticFiles();

            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{culture=en-US}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
