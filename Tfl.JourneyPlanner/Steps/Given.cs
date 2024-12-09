using Microsoft.Playwright;
using Tfl.JourneyPlanner.Context;
using Tfl.JourneyPlanner.Pages;

namespace Tfl.JourneyPlanner.Steps
{
    [Binding]
    public sealed class Given(PlanJourneyPage planPage, JourneyPlannerContext context)
    {
      
        [Given("user on the home page")]
        public async Task GivenUserOnTheHomePage()
        {
            await planPage.NavigateAsync();
        }

        [Given("the journey is planned from {string} to {string}")]
        public async Task GivenTheJourneyIsPlannedFromTo(string fromStation, string toStation)
        {
            
            await planPage.PlanTheJourney(fromStation, toStation);
        }

    }
}