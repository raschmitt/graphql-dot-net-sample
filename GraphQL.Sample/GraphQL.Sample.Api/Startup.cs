using System;
using GraphQL.Sample.Api.GraphQL;
using GraphQL.Sample.Domain.Interfaces.Repositories;
using GraphQL.Sample.Domain.Interfaces.Services;
using GraphQL.Sample.Domain.Services;
using GraphQL.Sample.Infra.Data.Data;
using GraphQL.Sample.Infra.Data.Data.Repositories;
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
                
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductReviewRepository, ProductReviewRepository>();
            services.AddScoped<IProductService, ProductService>();
            
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
                .AddEnvironmentVariables();
            
            Console.WriteLine("Environment:" + env.EnvironmentName);
            
            Configuration = builder.Build();
            
            var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var context = ServiceProviderServiceExtensions.GetRequiredService<Context>(serviceScope.ServiceProvider);
            
            context.Database.Migrate();
            context.Seed();
            
            app.UseGraphQL<Schema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                Path = "/ui/playground",
                HideTracingResponse = true,
            });
        }
        
        private string GetConnectionDefaultString() => Configuration.GetConnectionString("GraphQL.Sample");

        private static void EnableRetryOnFailure(SqlServerDbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);

        private void UseSqlServerDatabase(DbContextOptionsBuilder options) =>
            options.UseSqlServer(GetConnectionDefaultString(), EnableRetryOnFailure);
    }
}