namespace PageObjects.SearchPages
{
    using Core.Elements;
    using Core.Interfaces;
    using OpenQA.Selenium;
    using static Core.Utils.ElementFinder;

    public class SearchedPage : IPageObject
    {
       public ITextBox SearchResult = Get<Textbox>(By.XPath("//p[@class='ff-my-16']"), nameof(SearchResult)); 
    }
}
