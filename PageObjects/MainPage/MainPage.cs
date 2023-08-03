namespace PageObjects
{
    using Core.Elements;
    using Core.Interfaces;
    using OpenQA.Selenium;
    using static Core.Utils.ElementFinder;

    public class MainPage : IPageObject
    {
        public IButton PrivacyMessageConfirmButton => Get<Button>(By.Id("onetrust-accept-btn-handler"), nameof(PrivacyMessageConfirmButton));
        public IButton CloseBannerButton => Get<Button>(By.XPath("//header[contains(@class,'header')]//div[contains(@class,'overlay_bannerCloseBtn')]"), nameof(CloseBannerButton));
        public ILink LoginLink => Get<Link>(By.XPath("//a[contains(@href,'login')]//div"), nameof(LoginLink));

        public FifaPartnersSection FifaPartnersSection = new();
        public SocialNetworkSection SocialNetworkSection = new();
        public HeaderMenuSection HeaderMenuSection = new();
        public FooterLanguageSection FooterLanguageSection = new();
        public SearchSection SearchSection = new();
    }
}