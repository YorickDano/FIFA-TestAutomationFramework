namespace Core.UI
{
    using Core.Utils;
    using PageObjects;
    using TechTalk.SpecFlow;
    using Core.UI.Enums;

    [Binding]
    public static class SocialNetworksManager
    {
        [Given(@"I switch to social network ""(.*)""")]
        public static void GoToSocialNetwork(SocialNetwork socialNetwork)
        {
            var page = new MainPage();
            Logger.Info($"Try redirect to {socialNetwork} page");
            switch (socialNetwork)
            {
                case SocialNetwork.Instagram:
                    {
                        page.SocialNetworkSection.InstagramButton.Click();
                        break;
                    }
                case SocialNetwork.Twitter:
                    {
                        page.SocialNetworkSection.TwitterButton.Click();
                        break;
                    }
                case SocialNetwork.Facebook:
                    {
                        page.SocialNetworkSection.FacebookButton.Click();
                        break;
                    }
                case SocialNetwork.Youtube:
                    {
                        page.SocialNetworkSection.YoutubeButton.Click();
                        break;
                    }
                case SocialNetwork.Weibo:
                    {
                        page.SocialNetworkSection.WeiboButton.Click();
                        break;
                    }
                default: throw new ArgumentOutOfRangeException("Social network " + nameof(socialNetwork) + "doesn't exist!");
            }
            Logger.Info($"Successful redirection to {socialNetwork} page");
        }
    }
}
