namespace Core.UI
{
    using Core.Utils;
    using PageObjects;
    using TechTalk.SpecFlow;
    using Core.UI.Enums;

    [Binding]
    public class HeaderMenuManager
    {
        public static int GetLinkCount()
        {
            Logger.Info("Try to get header links count");
            return new MainPage().HeaderMenuSection.LinksList.Count();
        }

        [Given(@"I switch to header link ""(.*)""")]
        public static void GoToHeaderLink(HeaderLink headerLink)
        {
            var page = new MainPage();
            Logger.Info($"Try redirect to {headerLink} page");
            switch (headerLink)
            {
                case HeaderLink.Competitions:
                    {
                        page.HeaderMenuSection.CompetitionsButton.Click();
                        break;
                    }
                case HeaderLink.AboutFifa:
                    {
                        page.HeaderMenuSection.AboutFifaButton.Click();
                        break;
                    }
                case HeaderLink.WomensFootball:
                    {
                        page.HeaderMenuSection.WomensFootballButton.Click();
                        break;
                    }
                case HeaderLink.SocialImpact:
                    {
                        page.HeaderMenuSection.SocialImpactButton.Click();
                        break;
                    }
                case HeaderLink.FootballDevelopment:
                    {
                        page.HeaderMenuSection.FootballDevelopmentButton.Click();
                        break;
                    }
                case HeaderLink.Technical:
                    {
                        page.HeaderMenuSection.TechnicalButton.Click();
                        break;
                    }
                case HeaderLink.Legal:
                    {
                        page.HeaderMenuSection.LegalButton.Click();
                        break;
                    }
                case HeaderLink.WorldRanking:
                    {
                        page.HeaderMenuSection.WorldRankingButton.Click();
                        break;
                    }
                default: throw new ArgumentOutOfRangeException("Header link" + nameof(headerLink) + "doesn't exist!");
            }
            Logger.Info($"Successful redirection to {headerLink} page");
        }
    }
}
