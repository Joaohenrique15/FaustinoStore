using FaustinoStore.Domain.StoreContext.Handlers;
using FaustinoStore.Domain.StoreContext.Repositories;
using FaustinoStore.Domain.StoreContext.Services;
using FaustinoStore.Infra.DataContexts;
using FaustinoStore.Infra.StoreContext.Repositories;
using FaustinoStore.Infra.StoreContext.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FaustinoStore.Api
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

      services.AddScoped<FaustinoDataContext, FaustinoDataContext>();
      services.AddTransient<ICustomerRepository, CustomerRepository>();
      services.AddTransient<IEmailService, EmailService>();
      services.AddTransient<CustomerHandler, CustomerHandler>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();

      app.UseMvc();
    }
  }
}
