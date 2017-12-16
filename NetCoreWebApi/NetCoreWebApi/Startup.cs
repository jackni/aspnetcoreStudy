using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using NetCoreWebApi.Services;
using NetCoreWebApi.Infrastructure.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using IdentityServer4.AccessTokenValidation;

namespace NetCoreWebApi
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
            //DI
            services.AddScoped<IGreetingService, GreetingService>();
            services.AddTransient<ICalcuator, Calcuator>();
            services.AddScoped<IMathService, MathService>();

            services.AddScoped<IItemPriceService, ItemPriceService>();

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://localhost:44302";
                    options.RequireHttpsMetadata = false;

                    options.ApiName = "api1";
                });

            //mvc dependency
            services.AddMvc();

            //enable api version
            services.AddApiVersioning(v=>
            {
                v.ReportApiVersions = true;
                v.AssumeDefaultVersionWhenUnspecified = true;
                v.DefaultApiVersion = new ApiVersion(1, 0);
                v.ApiVersionReader = new HeaderApiVersionReader("api-version"); //This will add to http heading
            });

            //register logging as AOP
            services.AddScoped<LoggingActionFilterAttribute>();
            
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My Demo API", Version = "v1" });
                c.SwaggerDoc("v2", new Info { Title = "My Demo API", Version = "v2" });

                // Define the OAuth2.0 scheme that's in use (i.e. Implicit Flow)
                c.AddSecurityDefinition("oauth2", 
                    new OAuth2Scheme
                    {
                        Type = "oauth2",
                        Flow = "implicit",
                        AuthorizationUrl = "https://localhost:44302/connect/authorize",
                        TokenUrl = "http://localhost:44302/connect/token",
                        Scopes = new Dictionary<string, string>()
                        {
                            { "api1", "My Demo API" }
                        }
                    }
                );
               
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Demo API V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "My Demo API V2");
                c.ConfigureOAuth2("swaggerui", "", "", "Swagger UI");

                c.ShowRequestHeaders();
            });

            app.UseMvc();
        }
    }
}
