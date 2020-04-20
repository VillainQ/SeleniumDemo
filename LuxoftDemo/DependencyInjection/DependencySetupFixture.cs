using LuxoftDemo.DependencyInjection;
using LuxoftDemo.PageObjects;
using LuxoftDemo.Scenarios;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace LuxoftDemo
{
    public class DependencySetupFixture
    {
        public DependencySetupFixture()
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.Development.json").Build();

            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.Configure<UbsOptions>(configuration.GetSection("Ubs"));

            serviceCollection.AddTransient<ITestScenario<CookiesPage>, BaseTestScenario>();
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}
