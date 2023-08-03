namespace Tests.UI
{
    using Core.UI;
    using Core.UI.Enums;
    using FluentAssertions;
    using NUnit.Framework;
    using PageObjects;
    using PageObjects.SearchPages;
    using static Core.Utils.AssertsPool;

    public class FIFA2Tests : BaseTest
    {
        [Test]
        public void SearchSmokeTest()
        {
            ConfirmPrivacyManager.ConfirmPrivacy();
            Verify(() => SearchManager.IsSearchFieldOpen().Should().BeTrue());
        }

        [Test]
        public void SearchTest()
        {
            ConfirmPrivacyManager.ConfirmPrivacy();
            SearchedPage searchedPage = SearchManager.SearchFor("Playing Surfaces");
            Verify(() => SearchManager.GetCountOfSearchResults(searchedPage).Should().BeGreaterThan(1000));
        }

        [Test]
        public void TranslationOnRussianTest()
        {
            ConfirmPrivacyManager.ConfirmPrivacy();
            MainPage mainPage = new MainPage();
            LanguageManager.ChangeLanguageTo(Language.Russian);
            Verify(() => mainPage.LoginLink.GetValue().Should().Be("Войти"));
        }
    }
}
