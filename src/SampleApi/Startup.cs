using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace SampleApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvcCore()
                .AddJsonFormatters()
                .AddAuthorization();

            services.AddWebEncoders();
            services.AddCors();
            services.AddDistributedMemoryCache();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            Func<string, LogLevel, bool> filter = (scope, level) => 
                scope.StartsWith("Microsoft.AspNetCore.Authentication") || 
                scope.StartsWith("Microsoft.AspNetCore.Authorization") ||
                scope.StartsWith("IdentityServer") ||
                scope.StartsWith("IdentityModel") ||
                level == LogLevel.Error ||
                level == LogLevel.Critical;

            loggerFactory.AddConsole(filter);
            loggerFactory.AddDebug(filter);

            app.UseCors(policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            });

            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = "http://localhost:1941",
                RequireHttpsMetadata = false,

                EnableCaching = true,

                ScopeName = "api1",
                ScopeSecret = "secret",
                AutomaticAuthenticate = true
            });

            app.UseMvc();
        }
    }
}