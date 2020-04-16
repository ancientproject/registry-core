namespace registry
{
    using System;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static void Main(string[] args) 
            => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(Configure);


        public static void Configure(IWebHostBuilder webBuilder)
        {
            var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
            webBuilder
			.UseStartup<Startup>()
            .UseUrls($"http://*.*.*.*:{port}");
        }
    }
}
