using Microsoft.Playwright;
using Tfl.JourneyPlanner.Context;
using Tfl.JourneyPlanner.Pages;
namespace Tfl.JourneyPlanner.Steps
{
    [Binding]
    public sealed class Then(PlanJourneyPage planPage, JourneyResultsPage resultsPage, IPage page, JourneyPlannerContext context)
    {
        public IPage Page { get; } = page;
        public JourneyPlannerContext context { get; } = context;
        [Then("user clicks on plan for my journey")]
        public async Task ThenUserClicksOnPlanForMyJourneyAsync()
        {
            await planPage.ClickPlanMyJourney();
        }

        [Then("user should validate the walking time {int}mins and Cycling time {int}mins displayed")]
        public async Task ThenUserShouldValidateTheWalkingTimeMinsAndCyclingTimeMinsDisplayed(string walkingDurationText, string cyclingDurationText)
        {
            await resultsPage.ValidateWalkingTimeAndCyclingTime(walkingDurationText, cyclingDurationText);
        }

        [Then("I validate the journey time {int}mins is displayed correctly")]
        public async Task ThenIValidateTheJourneyTimeMinsIsDisplayedCorrectly(int p0)
        {
            await resultsPage.ValidateTheJourneyTime(p0);
        }

        [Then("user click on the View Details")]
        public async Task ThenUserClickOnTheViewDetails()
        {
            await resultsPage.ClickViewDetails();
        }

        [Then("verify complete access information")]
        public async Task ThenVerifyCompleteAccessInformation()
        {
            await resultsPage.VerifyCompleteAccessInformation();
        }

        [Then("Validate if widget is unable to plan the Journey")]
        public async Task ThenValidateIfWidgetIsUnableToPlanTheJourney()
        {
            await planPage.ValidateIfWidgetIsUnableToPlanTheJourney();
        }

        [Then("Validate widget provide invalid results")]
        public async Task ThenValidateWidgetProvideInvalidResults()
        {
            await resultsPage.ValidateWidgetProvideInvalidResults();
        }
    }
}
