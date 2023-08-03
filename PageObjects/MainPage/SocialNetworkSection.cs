namespace PageObjects
{
    using Core.Elements;
    using OpenQA.Selenium;
    using static Core.Utils.ElementFinder;

    public class SocialNetworkSection
    {
        public IButton InstagramButton => Get<Button>(By.XPath(GetSocialNetworkXpath("instagram")), nameof(InstagramButton));
        public IButton TwitterButton => Get<Button>(By.XPath(GetSocialNetworkXpath("twitter")), nameof(TwitterButton));
        public IButton FacebookButton => Get<Button>(By.XPath(GetSocialNetworkXpath("facebook")), nameof(FacebookButton));
        public IButton YoutubeButton => Get<Button>(By.XPath(GetSocialNetworkXpath("youtube")), nameof(YoutubeButton));
        public IButton WeiboButton => Get<Button>(By.XPath(GetSocialNetworkXpath("weibo")), nameof(WeiboButton));

        private static string GetSocialNetworkXpath(string networkName) => $"//a[contains(@href,'{networkName}')]";
    }
}
