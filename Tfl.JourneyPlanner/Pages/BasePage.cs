using Microsoft.Playwright;
namespace Tfl.JourneyPlanner.Pages;
public class BasePage
{
    protected readonly IPage Page;

    protected BasePage(IPage page)
    {
        Page = page;
    }
}