
namespace Catalog.API;

//TODO: change this file with the confifuration in the videos.

public class Program
{
    public static void Main(string[] args)
    {   
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}