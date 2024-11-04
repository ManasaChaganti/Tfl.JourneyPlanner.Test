using Microsoft.Playwright;
using Tfl.JourneyPlanner.Context;

namespace Tfl.JourneyPlanner.Steps
{
    [Binding]
    public sealed class When( JourneyResultsPage resultsPage, IPage page, JourneyPlannerContext context)
    {
        public IPage Page { get; } = page;
        public JourneyPlannerContext Context { get; } = context;

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