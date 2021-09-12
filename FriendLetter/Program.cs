using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace FriendLetter //same naming as the startup file to ensure that we can use the same code in between files
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = new WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseIISIntegration()
        .UseStartup<Startup>()
        .Build();

      host.Run();
    }
  }
}