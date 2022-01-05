using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TextEmAllChallenge.Context;
using TextEmAllChallenge.Repositories;

namespace TextEmAllChallenge
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
            // create configuration builder with appsettings.json file
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

            // build the configuration builder
            var config = builder.Build();

            // get the db connection string from the config builder
            string connectionString = config.GetValue<string>("ConnectionString");

            // add the db context, passing in the connection string
            services.AddDbContext<SchoolContext>(options => options.UseSqlServer(connectionString));

            // map the repository for dependency injection
            services.AddTransient<IStudentsRepository, StudentsRepository>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
