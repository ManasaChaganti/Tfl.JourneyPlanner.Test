using Microsoft.Playwright;
using Tfl.JourneyPlanner.Common;
using Tfl.JourneyPlanner.Config;

namespace Tfl.JourneyPlanner.Pages;

public class PlanJourneyPage(IPage page, TestConfiguration configuration) : BasePage(page: page)
{
    public async Task Navigate()
    {
        await Page.GotoAsync(configuration.Url);
        var locator = Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Accept all cookies" });
        if (await locator.IsVisibleAsync())
        {
            await locator.ClickAsync();
        }

        if (await Page.Locator("#cb-cookieoverlay").IsVisibleAsync())
        {
            await Page.EvaluateAsync("document.querySelector('#cb-cookieoverlay').style.display = 'none';");
        }
    }

    public async Task SetStation(string station, string destination)
    {
        await Page.ClickAsync(destination);
        await Page.GetByPlaceholder("Place or address").FillAsync(station.Substring(0, 3));
        var locator = Page.GetByRole(AriaRole.Option, new PageGetByRoleOptions { Name = station }).GetByRole(AriaRole.Strong);
        if (await locator.IsVisibleAsync())
        {
            await locator.ClickAsync();
        }
        else
        {
            await Page.GetByPlaceholder("Place or address").FillAsync(station);
        }
    }

    public async Task ClickPlanMyJourney()
    {
        await Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { NameString = "Plan my journey" }).ClickAsync();
    }
    public async Task PlanTheJourney(string fromStation, string toStation)
    {
        await Navigate();
        await SetStation(fromStation, Constants.Selectors.InputFrom);
        await SetStation(toStation, Constants.Selectors.InputTo);
    }

    public async Task ValidateIfWidgetIsUnableToPlanTheJourney()
    {
        await Assertions.Expect(page.Locator("#InputFrom-error")).ToContainTextAsync("The From field is required.");
        await Assertions.Expect(page.Locator("#InputTo-error")).ToContainTextAsync("The To field is required.");
    }
}