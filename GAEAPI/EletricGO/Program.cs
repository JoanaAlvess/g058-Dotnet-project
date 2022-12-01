using System;
using DDDSample1.Infrastructure;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DDDSample1
{
    public class Program
    {
        public static void Main(string[] args)
        {
          
            CreateWebHostBuilder(args).Build().Run();
        }

   

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
