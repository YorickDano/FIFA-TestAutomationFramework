namespace Tests.UI
{
    using Core.UI;
    using Core.Utils;
    using NUnit.Framework;
    using FluentAssertions;
    using Core.Services;
    using Core.UI.Enums;

    [TestFixture]
    class FIFATests : BaseTest
    {
        [Test]
        public void SearchAndReturnToMainPageTest()
        {
            ConfirmPrivacyManager.ConfirmPrivacy();
            SearchManager.SearchFor("Zinedin Zidane");
            SearchManager.ClickOnLogo();
            AssertsPool.Verify(() => BrowserPool.GetBrowser().GetCurrentUrl().Should().Be(Settings.BaseUrl));
        }

        [Test]
        public void WorldRankingTest()
        {
            ConfirmPrivacyManager.ConfirmPrivacy();
            WorldRankingManager.ClickOnCocaColaRankingButton();
            AssertsPool.Verify(() => WorldRankingManager.CountNumberOfCountries().Should().Be(10));
        }

        [Test]
        public void LinksAfterTranslationTest()
        {
            ConfirmPrivacyManager.ConfirmPrivacy();
            LanguageManager.ChangeLanguageTo(Language.Russian);
            AssertsPool.Verify(() => CheckLinksManager.CountNumberOfLinks().Should().Be(0));
        }
    }
}
