using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Model;
using Swashbuckle.SwaggerGen.Generator;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;

public class Handler {

    public IConfigurationRoot Configuration { get; }

    public Handler(IHostingEnvironment env)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();

        // if (env.IsDevelopment())
        // {
        //     // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
        //     builder.AddUserSecrets();
        // }

        Configuration = builder.Build();
    }

    public void ConfigureServices(IServiceCollection services)
    {

        // services.AddDbContext<DB>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

        services.AddDbContext<DB>(options => options.UseInMemoryDatabase());

        // services.AddIdentity<User, IdentityRole>()
        //     .AddEntityFrameworkStores<DB>()
        //     .AddDefaultTokenProviders();

        // services.AddApplicationInsightsTelemetry(Configuration);
        services.AddMvc();

        // services.AddSingleton<IRepository<Post>, PostRepo>();
        // services.AddTransient<IRepository<Post>, PostRepo>();
        // services.AddPost<IRepository<Post>, PostRepo>();

        // Inject an implementation of ISwaggerProvider with defaulted settings applied
        services.AddSwaggerGen();

        services.ConfigureSwaggerGen(options =>
        {
            options.SingleApiVersion(new Info
            {
                Version = "v1",
                Title = "Simple DB Example",
                Description = "A sample boilerplate for .NET Core"
            });
            options.IgnoreObsoleteActions();
            options.IgnoreObsoleteProperties();
            options.DescribeAllEnumsAsStrings();
        });
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger, DB db) {
        // logger.AddConsole(Configuration.GetSection("Logging"));
        logger.AddDebug();

        // if (env.IsDevelopment())
        // {
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
            // app.UseStatusCodePages();
        // }

        // app.UseApplicationInsightsRequestTelemetry();
        // app.UseApplicationInsightsExceptionTelemetry();

        app.UseStaticFiles();
        // app.UseIdentity();
        app.UseMvc(); //.AddXmlSerializerFormatters();
        // app.UseStatusCodePagesWithReExecute("/Home/Errors/{0}");
        // Seed.Initialize(db);
        
        // Enable middleware to serve generated Swagger as a JSON endpoint
        app.UseSwagger();

        // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
        app.UseSwaggerUi();
    }

}