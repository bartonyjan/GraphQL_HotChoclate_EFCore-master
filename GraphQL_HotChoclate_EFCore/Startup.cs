using AspNetCore.SpaServices.Extensions.Vue;
using GraphQL_HotChoclate_EFCore.GraphQL;
using GraphQL_HotChoclate_EFCore.Models;
using GraphQL_HotChoclate_EFCore.Services;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_HotChoclate_EFCore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyMethod().AllowAnyHeader()));
            services.AddCors();

            services.AddDbContext<DatabaseContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));

            services.AddControllers();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddScoped<Query>();
            services.AddScoped<Mutation>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ILocationService, LocationService>();

            services.AddGraphQL(c => SchemaBuilder.New()
                                                  .AddServices(c)
                                                  //.AddType<GraphQLTypes>()
                                                  .AddQueryType<Query>()
                                                  .AddMutationType<Mutation>()
                                                  .Create());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            //app.UseCors();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UsePlayground(new PlaygroundOptions
                {
                    QueryPath = "/api2",
                    Path = "/playground"
                });
            }

            app.UseGraphQL("/api2");

            app.UseHttpsRedirection();
            app.UseSpaStaticFiles();

            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.MapWhen(a => !a.Request.Path.Value.StartsWith("/api/"), builder =>
            {
                builder.UseSpa(spa =>
                {
                    spa.Options.SourcePath = "ClientApp";

                    // Development use webpack development server with Hot Module Replacement
                    if (env.IsDevelopment())
                    {
                        spa.UseVueDevelopmentServer();
                    }
                });
            });
        }
    }
}
