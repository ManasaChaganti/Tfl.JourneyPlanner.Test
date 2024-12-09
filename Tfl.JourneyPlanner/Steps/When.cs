using Microsoft.Playwright;
using Tfl.JourneyPlanner.Context;

namespace Tfl.JourneyPlanner.Steps
{
    [Binding]
    public sealed class When( JourneyResultsPage resultsPage)
    {

        [When("user update the journey")]
        public async Task WhenUserUpdateTheJourney()
        {
            await resultsPage.UpdateTheJourney();
        }

        [When("user edit preferences to select routes with least walking")]
        public async Task WhenUserEditPreferencesToSelectRoutesWithLeastWalking()
        {
            await resultsPage.EditPreferencesToSelectRoutesWithLeastWalking();
        }
    }
}