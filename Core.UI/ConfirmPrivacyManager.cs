namespace Core.UI
{
    using Core.Utils;
    using PageObjects;
    using TechTalk.SpecFlow;

    [Binding]
    public static class ConfirmPrivacyManager
    {
        [Given("I confirm privacy")]
        public static void ConfirmPrivacy()
        {
            Logger.Info("Start to confirm privacy on the page");
            new MainPage()
                        .PrivacyMessageConfirmButton.Click<MainPage>()
                        .CloseBannerButton.Click<MainPage>();
            Logger.Info("Privacy successfully confirmed!");
        }
    }
}
