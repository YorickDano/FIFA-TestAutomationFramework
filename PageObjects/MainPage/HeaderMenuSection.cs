namespace PageObjects
{
    using Core.Elements;
    using OpenQA.Selenium;
    using static Core.Utils.ElementFinder;

    public class HeaderMenuSection
    {
        public IEnumerable<IButton> LinksList => GetElements<Button>(By.XPath("//ul[contains(@class,'menuDiv')]/li"), nameof(LinksList));
        public IButton CompetitionsButton => Get<Button>(By.XPath(GetLinkXpath("Competitions")), nameof(CompetitionsButton));
        public IButton AboutFifaButton => Get<Button>(By.XPath(GetLinkXpath("About FIFA")), nameof(AboutFifaButton));
        public IButton WomensFootballButton => Get<Button>(By.XPath(GetLinkXpath("Women's football")), nameof(WomensFootballButton));
        public IButton SocialImpactButton => Get<Button>(By.XPath(GetLinkXpath("Social Impact")), nameof(SocialImpactButton));
        public IButton FootballDevelopmentButton => Get<Button>(By.XPath(GetLinkXpath("Football Development")), nameof(FootballDevelopmentButton));
        public IButton TechnicalButton => Get<Button>(By.XPath(GetLinkXpath("Technical")), nameof(TechnicalButton));
        public IButton LegalButton => Get<Button>(By.XPath(GetLinkXpath("Legal ")), nameof(LegalButton));
        public IButton WorldRankingButton => Get<Button>(By.XPath(GetLinkXpath("World Ranking")), nameof(WorldRankingButton));

        private static string GetLinkXpath(string linkName) => $"//ul[contains(@class,'menuDiv')]//a[text()='{linkName}']";
    }
}
