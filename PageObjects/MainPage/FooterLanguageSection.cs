namespace PageObjects
{
    using Core.Elements;
    using OpenQA.Selenium;
    using static Core.Utils.ElementFinder;

    public class FooterLanguageSection
    {
        public IButton LanguageButton => Get<Button>(By.XPath("//button[contains(@class,'dropupButton')]"), nameof(LanguageButton));
        public IButton EnglishButton => Get<Button>(By.XPath(LanguageXpath("English")), nameof(EnglishButton));
        public IButton EspanolButton => Get<Button>(By.XPath(LanguageXpath("Español")), nameof(EspanolButton));
        public IButton FrancaisButton => Get<Button>(By.XPath(LanguageXpath("Français")), nameof(FrancaisButton));
        public IButton DeutschButton => Get<Button>(By.XPath(LanguageXpath("Deutsch")), nameof(DeutschButton));
        public IButton ArabianButton => Get<Button>(By.XPath(LanguageXpath("العربية")), nameof(ArabianButton));
        public IButton LietuviuButton => Get<Button>(By.XPath(LanguageXpath("Lietuvių")), nameof(LietuviuButton));
        public IButton RussianButton => Get<Button>(By.XPath(LanguageXpath("Pусский")), nameof(RussianButton));
        public IButton JapaneseButton => Get<Button>(By.XPath(LanguageXpath("日本語")), nameof(JapaneseButton));

        private static string LanguageXpath(string languageName) => $"//div[contains(@class,'dropupContent')]//a[text()='{languageName}']";
    }
}
