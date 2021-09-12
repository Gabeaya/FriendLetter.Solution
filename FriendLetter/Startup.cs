using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//this import namespaces that can help 
//construct http requests, configure our project, and present necessary built in functionality in correct areas

namespace FriendLetter 
//common naming convention for namespace is to title it the folder the file is within
{
  public class Startup
  {
    public Startup(IWebHostEnvironment env) //iteration of class 
    {
      //below is required configuration for ASP.Net Core to run
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }
    
    //ConfigureServices sets up the applications server
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();//adds the mvc service to our project
    }

    public void Configure(IApplicationBuilder app)
    //Configure is called on when the app launches
    {
      app.UseDeveloperExceptionPage();  //provides a human jargon of the error

      app.UseRouting();

      app.UseEndpoints(routes =>
      {
        routes.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"); //tells project to use the index action of the home controller as the defaulet route
      });
      //tells our app to use the MVC framework to respond to HTTP requests
      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("Hello World!");
        //this tells our app to print the following string if a proper mvc route canna be found
      });
    }
  }
}