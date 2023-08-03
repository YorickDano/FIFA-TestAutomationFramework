namespace Core.UI
{
    using Core.Utils;
    using PageObjects;
    using PageObjects.SearchPages;


    public static class SearchManager
    {
        public static SearchedPage SearchFor(string info)
        {
            Logger.Info($"Try to search for {info}");

            MainPage mainPage = new();
            mainPage.SearchSection.SearchButton.Click<SearchSection>().
                SearchField.SendKeys(info);
            mainPage.SearchSection.ConfirmButtonInitialization();
            mainPage.SearchSection.ConfirmButton.Click();

            Logger.Info($"{info} is successfully found");

            return new SearchedPage();
        }

        public static MainPage ClickOnLogo()
        {
            Logger.Info("Click on FIFA logo button");
            return new Header().LogoButton.Click<MainPage>();
        }

        public static bool IsSearchFieldOpen()
        {
            Logger.Info($"Try to make sure that SearchField is opened");

            MainPage mainPage = new();
            return mainPage.SearchSection.SearchField.GetValueOfAttribute("placeholder").Contains("Search for");
        }

        public static int GetCountOfSearchResults(SearchedPage searchedPage) =>
          int.Parse(searchedPage.SearchResult.GetValueOfAttribute("innerText").Split(' ')[5]);
    }
}