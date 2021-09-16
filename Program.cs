using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Kira.Serverless.Runtime.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Prometheus;
using Kira.Serverless.Runtime.Utils;
using Kira.Serverless.Runtime.Router;

namespace OniCloud.Lira.FaaS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices(services => services.RegisterFunctions(typeof(Program).Assembly));
                    webBuilder.Configure(app =>
                    {
                        app.UseRouting();
                        app.UseMetricServer(FaasUtils.GetMetricsEndpoint());
                        app.UseEndpoints(endpoints => endpoints.MapFunctions());
                    });
                });
    }
}
