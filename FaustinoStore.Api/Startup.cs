using System.IO;
using FaustinoStore.Domain.StoreContext.Handlers;
using FaustinoStore.Domain.StoreContext.Repositories;
using FaustinoStore.Domain.StoreContext.Services;
using FaustinoStore.Infra.DataContexts;
using FaustinoStore.Infra.StoreContext.Repositories;
using FaustinoStore.Infra.StoreContext.Services;
using FaustinoStore.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FaustinoStore.Api
{
  public class Startup
  {
    public static IConfiguration Configuration { get; set; }
    public void ConfigureServices(IServiceCollection services)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json");

      Configuration = builder.Build();

      services.AddControllers();

      services.AddResponseCompression();

      services.AddScoped<FaustinoDataContext, FaustinoDataContext>();
      services.AddTransient<ICustomerRepository, CustomerRepository>();
      services.AddTransient<IEmailService, EmailService>();
      services.AddTransient<CustomerHandler, CustomerHandler>();

      services.AddSwaggerGen(x =>
      {
        x.SwaggerDoc("v1", new OpenApiInfo { Title = "FaustinoStore", Version = "v1" });
      });

      Settings.ConnectionString = $"{Configuration["connectionString"]}";
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();

      app.UseRouting();
      app.UseEndpoints(endpoints =>
        {
          endpoints.MapControllers();
        });

      app.UseResponseCompression();

      app.UseSwagger();
      app.UseSwaggerUI(c =>
        {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "FaustinoStore - v1");
        });

    }
  }
}
