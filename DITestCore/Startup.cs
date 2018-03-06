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
using Microsoft.EntityFrameworkCore;

using DITestCore.DAL;

namespace DITestCore
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
            //var connection = @"Server =.\; Database = DITestCore; Trusted_Connection = True; MultipleActiveResultSets = true";
            //services.AddDbContext<DITestCore.DAL.DITestCoreContext>(options => options.UseSqlServer(connection));

            //services.AddMvc();

            //services.AddScoped<ICustomerFactory, CustomerFactory>();



            DITestCore.DAL.DITestCoreContext dbContext = new DITestCoreContext();
            dbContext.InitializeDB();
            dbContext.Container = services;
            services.AddSingleton(typeof(DITestCoreContext), dbContext);

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
