using Microsoft.Playwright;
using Tfl.JourneyPlanner.Pages;

public class JourneyResultsPage(IPage page) : BasePage(page)
{
    public async Task ValidateWalkingTimeAndCyclingTime(string walkingTime, string cyclingTime)
    {
        await Assertions.Expect(page.Locator("#full-width-content")).ToContainTextAsync(walkingTime);
        await Assertions.Expect(page.Locator("#full-width-content")).ToContainTextAsync(cyclingTime);
    }

    public async Task EditPreferencesToSelectRoutesWithLeastWalking()
    {
        await page.GetByRole(AriaRole.Button, new() { Name = "Edit preferences" }).ClickAsync();
        await page.GetByText("Routes with least walking").ClickAsync();
    }

    public async Task UpdateTheJourney()
    {
        await page.GetByRole(AriaRole.Button, new() { Name = "Update journey" }).ClickAsync();
    }

    public async Task ValidateTheJourneyTime(int p0)
    {
        await Assertions.Expect(page.Locator("#option-1-heading")).ToContainTextAsync("Total time");

    }

    public async Task VerifyCompleteAccessInformation()
    {
        await page.GetByRole(AriaRole.Link, new() { Name = "Up stairs" }).IsVisibleAsync();
        await page.GetByRole(AriaRole.Link, new() { Name = "Level walkway" }).IsVisibleAsync();
        await Assertions.Expect(page.GetByLabel("Option 1: walking, Piccadilly").GetByText("Covent Garden Underground").Nth(1)).ToBeVisibleAsync();

    }
    public async Task ValidateWidgetProvideInvalidResults()
    {
        await Assertions.Expect(page.Locator("#full-width-content")).ToContainTextAsync("Sorry, we can't find a journey matching your criteria");

    }
    public async Task ClickViewDetails()
    {
        await page.GetByLabel("Option 1: walking, Piccadilly").GetByText("View details").ClickAsync();
    }
}
