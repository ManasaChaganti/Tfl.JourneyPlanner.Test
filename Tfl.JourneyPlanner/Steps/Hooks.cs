using System.Reflection;
using Microsoft.Playwright;
using NUnit.Framework;
using Reqnroll.BoDi;
using Tfl.JourneyPlanner.Pages;

namespace Tfl.JourneyPlanner.Steps
{
    [Binding]
    public sealed class Hooks(PlanJourneyPage homePage)
    {
        public PlanJourneyPage HomePage { get; } = homePage;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Assertions.SetDefaultExpectTimeout(10000);
        }

        [AfterScenario]
        public async Task AfterScenario(IPage page, ScenarioContext scenarioContext, IBrowser browser, IObjectContainer container)
        {
            if (scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError)
            {
                var rootFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var screenshotsFolder = Path.Combine(rootFolder!, "screenshots");

                var fileName = string.Concat(scenarioContext.ScenarioInfo.Title.Split(Path.GetInvalidFileNameChars()));
                fileName = fileName.Replace(" ", "");
                var path = Path.Combine(screenshotsFolder, $"{fileName}.jpg");
                await page.ScreenshotAsync(new()
                {
                    Path = path,
                    FullPage = true,
                });

                if (page.Video != null)
                {
                    var videoPath = await page.Video.PathAsync();
                    TestContext.AddTestAttachment(videoPath);
                }
            }
        }
    }
}