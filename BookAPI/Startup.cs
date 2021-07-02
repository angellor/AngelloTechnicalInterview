using BookAPI.Data.Models;
using BookAPI.Data.Repos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BookAPI
{
   public class Startup
   {
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      
      public void ConfigureServices(IServiceCollection services)
      {

         services.AddScoped<IBookRepo, BookRepo>();

         services.AddDbContext<BookDbContext>(options => options.UseSqlite("Data source=bookcatalog.db"));

         services.AddControllers();
         services.AddSwaggerGen(c =>
         {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookAPI", Version = "v1" });
         });
      }

      
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookAPI v1"));
         }

         app.UseHttpsRedirection();
         app.UseRouting();

         //Add cors for UI project
         app.UseCors(option => option.WithOrigins("https://localhost:44337/")
         .AllowAnyHeader()
         .AllowAnyMethod()
         .SetIsOriginAllowed((host) => true)
         .AllowCredentials());

         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllers();
         });
      }
   }
}
