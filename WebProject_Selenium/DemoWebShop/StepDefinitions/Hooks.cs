using DemoWebShop.SeleniumHelpers;
using TechTalk.SpecFlow;

namespace DemoWebShop.StepDefinitions
{
    [Binding]
    public sealed class Hooks
    {
        private readonly Helpers _seleniumHelpers;

        public Hooks(Helpers seleniumHelpers)
        {
            _seleniumHelpers = seleniumHelpers;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _seleniumHelpers.DisposeDriver();
        }
    }
}
