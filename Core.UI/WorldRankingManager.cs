namespace Core.UI
{
    using Core.Utils;
    using PageObjects.Footer;
    using PageObjects.WorldRankingPage;
    using TechTalk.SpecFlow;

    [Binding]
    public static class WorldRankingManager
    {
        [Given(@"I click on CocaCola ranking button")]
        public static void ClickOnCocaColaRankingButton()
        {
            Logger.Info("Go to Coca-Cola World Ranking page");
            new Footer().CocaColaRankingButton.Click<Footer>();
        }

        public static int CountNumberOfCountries()
        {
            Logger.Info("Counting number of countries in the table");
            return new WorldRankingPage().TableRankingMen.ToList().Count();
        }
    }
}
