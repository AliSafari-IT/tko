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
using Microsoft.OpenApi.Models;
using XtxDocumentation.DocApi.Data;

namespace XtxDocumentation.DocApi
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
      //Enable CORS
      services.AddCors(c =>
      {
        c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
      });


      services.AddControllers();
      services
          .AddSwaggerGen(c =>
          {
            c
                      .SwaggerDoc("v1",
                      new OpenApiInfo
                  {
                    Title = "NxTdm.DocApi",
                    Version = "v1"
                  });
          });
        services.AddDbContext<DocuDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
  }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app
          .UseCors(options =>
              options
                  .WithOrigins("*")
                  .AllowAnyMethod()
                  .AllowAnyHeader());

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app
            .UseSwaggerUI(c =>
                c
                    .SwaggerEndpoint("/swagger/v1/swagger.json",
                    "NxTdm.DocApi v1"));
      }

      app.UseRouting();

      app.UseAuthorization();

      app
          .UseEndpoints(endpoints =>
          {
            endpoints.MapControllers();
          });
    }
  }

}
