using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace LandingPage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            bool isPPE = false;
            #if PPE_ENV
            isPPE = true;
            #endif

            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfigurationBuilder configBuidler = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            if (isPPE)
            {
                configBuidler.AddJsonFile("appsettings.PPE.json", false, true);
                environment = "Development";
            }
            else
            {
                configBuidler.AddJsonFile($"appsettings.{environment}.json", true, true);
            }


            IConfigurationRoot configuration = configBuidler.Build();
            if (isPPE)
            {
                configuration["environment"] = "PPE";
            }

            return WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(configuration)
                .UseStartup<Startup>();
        }
            
    }
}
