using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using ElectronNET.API;

namespace YouthApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseElectron(args)
                .Build();
    }
}
