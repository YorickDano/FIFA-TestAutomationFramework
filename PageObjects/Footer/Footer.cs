namespace PageObjects.Footer
{
    using Core.Elements;
    using OpenQA.Selenium;
    using static Core.Utils.ElementFinder;

    public class Footer : IPageObject
    {
        public IButton CompetitionsButton =>
            Get<Button>(By.XPath("//*[@class='ff-mb-8']//*[contains(@href,'tournaments')]"), nameof(CompetitionsButton));
        public IButton AboutFIFAButton =>
            Get<Button>(By.XPath("//*[@class='ff-mb-8']//*[contains(@href,'bout-fifa')]"), nameof(AboutFIFAButton));
        public IButton WomensFootballButton =>
            Get<Button>(By.XPath("//*[@class='ff-mb-8']//*[contains(@href,'womens-football')]"), nameof(WomensFootballButton));
        public IButton SocialImpactButton =>
            Get<Button>(By.XPath("//*[@class='ff-mb-8']//*[contains(@href,'social-impact')]"), nameof(SocialImpactButton));
        public IButton FootballDevButton =>
            Get<Button>(By.XPath("//*[@class='ff-mb-8']//*[contains(@href,'football-development')]"), nameof(FootballDevButton));
        public IButton TechnicalButton =>
            Get<Button>(By.XPath("//*[@class='ff-mb-8']//*[contains(@href,'technical')]"), nameof(TechnicalButton));
        public IButton LegalComplianceButton =>
            Get<Button>(By.XPath("//*[@class='ff-mb-8']//*[contains(@href,'legal')]"), nameof(LegalComplianceButton));
        public IButton CocaColaRankingButton =>
            Get<Button>(By.XPath("//*[@class='ff-mb-8']//*[contains(@href,'fifa-world-ranking')]"), nameof(CocaColaRankingButton));
        public IButton AllStoriesButton =>
            Get<Button>(By.XPath("//*[@class='ff-mb-8']//*[contains(@href,'all-stories')]"), nameof(AllStoriesButton));
        public IButton OfficialDocumentsButton =>
            Get<Button>(By.XPath("//*[@class='ff-mb-8']//*[contains(@href,'about-fifa/official-documents')]"), nameof(OfficialDocumentsButton));
        public IButton JobsCareersButton =>
            Get<Button>(By.XPath("//*[@class='ff-mb-8']//*[contains(@href,'careers')]"), nameof(JobsCareersButton));
        public IButton ContactFIFAButton =>
            Get<Button>(By.XPath("//*[@class='ff-mb-8']//*[contains(@href,'about-fifa/organisation/contact-fifa')]"), nameof(ContactFIFAButton));
        public IEnumerable<Button> ListOfLinksToOtherPages =>
            GetElements<Button>(By.XPath("//*[@class='ff-mb-8' and text()='']"), nameof(ListOfLinksToOtherPages));
    }
}
