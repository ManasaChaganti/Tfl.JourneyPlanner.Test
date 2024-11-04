using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;
using NUnit.Framework;
using Reqnroll.Autofac;
using Reqnroll.Autofac.ReqnrollPlugin;
using Tfl.JourneyPlanner.Config;
using Tfl.JourneyPlanner.Context;
using Tfl.JourneyPlanner.Pages;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using ContainerBuilder = Autofac.ContainerBuilder;

namespace Tfl.JourneyPlanner.Common;

public class Startup
{
    [ScenarioDependencies]
    public static void ConfigDep(ContainerBuilder builder)
    {
        var services = new ServiceCollection();

        var configPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
            TestConfiguration.FileName);

        var testConfig = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build()
            .Deserialize<TestConfiguration>(File.ReadAllText(configPath));
        services.AddSingleton(testConfig);

        services.AddScoped(_ => new JourneyPlannerContext());
        services.AddScoped(_ => Playwright.CreateAsync().ConfigureAwait(false).GetAwaiter().GetResult());
        services.AddScoped(p =>
        {
            var configuration = p.GetRequiredService<TestConfiguration>();
            var playwright = p.GetRequiredService<IPlaywright>();
            var browserTypeLaunchOptions = new BrowserTypeLaunchOptions
            {
                Channel = "chrome",
                Headless = testConfig.BrowserOptions.Headless,
                Timeout = 10000,
            };

            if (configuration.BrowserOptions.StartMaximized)
            {
                browserTypeLaunchOptions.Args = ["--start-maximized"];
            }

            return playwright.Chromium.LaunchAsync(browserTypeLaunchOptions).ConfigureAwait(false).GetAwaiter().GetResult();
        });


        services.AddScoped(p =>
        {
            var browser = p.GetRequiredService<IBrowser>();
            var configuration = p.GetRequiredService<TestConfiguration>();
            var videoDir = Path.Combine(TestContext.CurrentContext.TestDirectory, "Videos");
            var browserNewContextOptions = new BrowserNewContextOptions()
            {
                BaseURL = configuration.Url,
                ViewportSize = ViewportSize.NoViewport,
            };

            if (configuration.BrowserOptions.RecordVideo)
            {
                browserNewContextOptions.RecordVideoDir = videoDir;
                browserNewContextOptions.RecordVideoSize = new RecordVideoSize
                { Height = configuration.BrowserOptions.Height, Width = configuration.BrowserOptions.Width };
            }

            if (configuration.BrowserOptions.Headless)
            {
                browserNewContextOptions.ViewportSize = new ViewportSize
                { Height = configuration.BrowserOptions.Height, Width = configuration.BrowserOptions.Width };
            }

            var browserContext = browser.NewContextAsync(browserNewContextOptions).GetAwaiter().GetResult();

            var page = browserContext.NewPageAsync().GetAwaiter().GetResult();
            return page;
        });

        builder.Populate(services);
        builder.RegisterAssemblyTypes(typeof(PlanJourneyPage).Assembly).Where(x => x.IsAssignableTo<BasePage>())
            .Where(x => x != typeof(BasePage)).InstancePerDependency();
        builder.AddReqnrollBindings<Startup>();
    }
}