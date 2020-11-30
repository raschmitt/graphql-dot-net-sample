using System;
using GraphQL.Sample.Api.Data;
using GraphQL.Sample.Api.Data.Repositories;
using GraphQL.Sample.Api.GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Sample.Api
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(UseSqlServerDatabase);
                
            services.AddScoped<ProductRepository>();
            services.AddScoped<ProductReviewRepository>();

            services.AddScoped<Query>();
            services.AddScoped<Mutation>();
            services.AddScoped<Schema>();

            services.AddGraphQL()
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddDataLoader()
                .AddSystemTextJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                // .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            
            Configuration = builder.Build();
            
            // Console.WriteLine($"Running on environment: {env.EnvironmentName}");

            var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var context = ServiceProviderServiceExtensions.GetRequiredService<Context>(serviceScope.ServiceProvider);
            
            context.Database.Migrate();
            context.Seed();
            
            app.UseGraphQL<Schema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
        
        private string GetConnectionDefaultString() => Configuration.GetConnectionString("GraphQL.Sample");

        private static void EnableRetryOnFailure(SqlServerDbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);

        private void UseSqlServerDatabase(DbContextOptionsBuilder options) =>
            options.UseSqlServer(GetConnectionDefaultString(), EnableRetryOnFailure);
    }
}