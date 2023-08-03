namespace Core.SpecFlow.StepDefinitions
{
    using Core.Services;
    using Core.Utils;

    [Binding]
    public class BaseStepDefinitions
    {
        [BeforeScenario]
        public void SetUp()
        {
            switch (ScenarioContext.Current.ScenarioInfo.Tags.GetValue(0)){
                case "UI":
                    {
                        BrowserPool.CreateBrowser();
                        BrowserPool.GetBrowser().OpenInFullScreen();
                        break;
                    }
                case "API":
                    {
                        APIClientPool.CreateAPIClient();
                        break;
                    }
                default: throw new ArgumentException($"Incorrect tag value: {ScenarioContext.Current.ScenarioInfo.Tags.GetValue(0)}");
            }
            AssertsPool.Register();
        }

        [AfterScenario]
        public void TearDown()
        {
            switch (ScenarioContext.Current.ScenarioInfo.Tags.GetValue(0)){
                case "UI":
                    {
                        BrowserPool.CloseBrowser();
                        break;
                    }
                case "API":
                    {
                        APIClientPool.CloseAPIClient();
                        break;
                    }
                default: throw new ArgumentException($"Incorrect tag value: {ScenarioContext.Current.ScenarioInfo.Tags.GetValue(0)}");
            }
            AssertsPool.IsPassed();
        }
    }
}
