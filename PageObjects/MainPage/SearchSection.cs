namespace PageObjects
{
    using Core.Elements;
    using Core.Interfaces;
    using OpenQA.Selenium;
    using static Core.Utils.ElementFinder;

    public class SearchSection : IPageObject
    {
        public IButton SearchButton = Get<Button>(By.XPath("//div[contains(@class,'ff-pr-32 fc')]"), nameof(SearchButton));

        public ITextBox SearchField = Get<Textbox>(By.XPath("//input[contains(@aria-label,'Search for')]"), nameof(SearchField));

        public IButton ConfirmButton;

        public void ConfirmButtonInitialization()
        {
            ConfirmButton = Get<Button>(By.XPath("//a[contains(@href,'search-results') and contains(@class,'searchIcon')]"));
        }
    }
}
