using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Webjobs.Managers;
using Webjobs.Services;

namespace Webjobs
{
    public class Program
    {
        private static IBatService _service;

        public static void Main(string[] args)
        {
            Setup();

            _service.Sample1();
            // ログの出力が間に合わないため
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Hello World!");
        }

        public static void Setup()
        {
            if (_service != null)
            {
                return;
            }
            Console.WriteLine("Setup Local.");

            var builder = new HostBuilder().ConfigureAppConfiguration((context, config) => {
                config.AddJsonFile("appsettings.json", optional: false);
                config.AddEnvironmentVariables();
            }).ConfigureServices(services => {
                services.AddOptions<WebjobsConfigManager>().Configure<IConfiguration>((x, y) => {
                    y.Bind(x);
                    y.GetSection("WebjobsValue").Bind(x);
                    x.ConnString = y.GetConnectionString("ConnString");
                });
                services.AddLogging(y => y.AddConsole());
                services.AddSingleton<IBatService, BatService>();
            });
            var host = builder.Build();

            Setup(host.Services.GetService<IBatService>());
        }

        public static void Setup(IBatService service)
        {
            _service = service;
        }
    }
}
