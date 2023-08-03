namespace Core.UI
{
    using Core.Utils;
    using PageObjects;
    using TechTalk.SpecFlow;
    using Core.UI.Enums;

    [Binding]
    public static class LanguageManager
    {
        [Given(@"I change language to ""(.*)""")]
        public static void ChangeLanguageTo(Language language)
        {
            Logger.Info($"Try to change language to {language}");
            var page = new MainPage();
            page.FooterLanguageSection.LanguageButton.Click();
            switch (language)
            {
                case Language.English:
                    {
                        page.FooterLanguageSection.EnglishButton.Click();
                        break;
                    }
                case Language.Espanol:
                    {
                        page.FooterLanguageSection.EspanolButton.Click();
                        break;
                    }
                case Language.Francais:
                    {
                        page.FooterLanguageSection.FrancaisButton.Click();
                        break;
                    }
                case Language.Deutsch:
                    {
                        page.FooterLanguageSection.ArabianButton.Click();
                        break;
                    }
                case Language.Lietuviu:
                    {
                        page.FooterLanguageSection.LietuviuButton.Click();
                        break;
                    }
                case Language.Russian:
                    {
                        page.FooterLanguageSection.RussianButton.Click();
                        break;
                    }
                case Language.Japanese:
                    {
                        page.FooterLanguageSection.JapaneseButton.Click();
                        break;
                    }
                    default: throw new ArgumentOutOfRangeException($"This language doesn't exist: {language}");
            }
            Logger.Info($"Language successfully changed to {language}");
        }
    }
}
