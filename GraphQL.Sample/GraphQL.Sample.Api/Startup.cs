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
        private readonly IConfiguration _config;
        private readonly IHostingEnvironment _env;

        public Startup(IConfiguration config, IHostingEnvironment env)
        {
            _config = config;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<Context>(UseSqlServerDatabase);
                
            services.AddScoped<ProductRepository>();
            services.AddScoped<ProductReviewRepository>();

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<Schema>();

            services.AddGraphQL(o => { o.ExposeExceptions = false; })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddDataLoader();
        }

        public void Configure(IApplicationBuilder app, Context dbContext)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            
            Console.WriteLine($"Running on environment: {_env.EnvironmentName}");
            
            app.UseGraphQL<Schema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            dbContext.Database.Migrate();
            dbContext.Seed();
        }
        
        private string GetConnectionDefaultString() => _config.GetConnectionString("GraphQL.Sample");

        private static void EnableRetryOnFailure(SqlServerDbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);

        private void UseSqlServerDatabase(DbContextOptionsBuilder options) =>
            options.UseSqlServer(GetConnectionDefaultString(), EnableRetryOnFailure);
    }
}