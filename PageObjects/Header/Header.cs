namespace PageObjects
{
    using Core.Elements;
    using Core.Utils;
    using Core.Interfaces;
    using OpenQA.Selenium;
    using static Core.Utils.ElementFinder;

    public class Header : IPageObject
    {
        public IButton SearchIconButton => Get<Button>(By.XPath("//div[contains(@class,'ff-pr-32 fc')]"), nameof(SearchIconButton));
        public IButton SearchButton => Get<Button>(By.XPath("//a[contains(@class,'searchIconActiveWrapper')]"), nameof(SearchButton));
        public ITextBox SearchField => Get<Textbox>(By.XPath("//input[contains(@aria-label,'Search for')]"), nameof(SearchField));
        public IButton LogoButton => Get<Button>(By.XPath("//a[contains(@class, 'ff-mb-0 d-flex')]"), nameof(LogoButton));
    }
}
