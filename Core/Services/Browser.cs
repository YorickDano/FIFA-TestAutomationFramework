namespace Core.Services
{
    using Core.Elements;
    using Models.BrowserSettings;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Collections.Generic;
    using static Core.Services.DriverFactory;
    using static Configuration.ConfigurationManager;
    using SeleniumExtras.WaitHelpers;

    public class Browser : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly TabManager tabManager;
        private readonly BrowserSettingsModel browserSettings;
       
        public Browser() 
        {
            browserSettings = GetConfiguration<BrowserSettingsModel>();
            driver = GetDriver(browserSettings.BrowserName);
            tabManager = new TabManager(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(browserSettings.ImplicitWait);
            driver.Url = browserSettings.BaseUrl;
        
        }

        internal IWebElement FindElement(By by)
        {
            return GetWebDriverWait().Until((driver) => driver.FindElement(by));
        }
        internal IReadOnlyList<IWebElement> FindElements(By by)
        {
            return GetWebDriverWait().Until<IReadOnlyList<IWebElement>>((driver) => driver.FindElements(by));
        }
        public void GoToUrl(string url) => driver.Navigate().GoToUrl(url);
        public void OpenInFullScreen() => driver.Manage().Window.Maximize();
        public void RefreshPage() => driver.Navigate().Refresh();
        internal void ExecuteJsScript(string script) => ((IJavaScriptExecutor)driver).ExecuteScript(script);
        public void SwitchToTab(int tabNumber) => tabManager.SwitchToTab(tabNumber);
        public void OpenNewTab() => tabManager.OpenNewTab();
        public void AddItemToLocalStorage(string key, string value)
        {
            var script = string.Format($"localStorage.setItem({key},{value})");
            ExecuteJsScript(script);
        }
        public string GetCurrentUrl() => driver.Url;
        public void DeleteAllCookies() => driver.Manage().Cookies.DeleteAllCookies();
        public void Dispose() => driver.Dispose();
        internal WebDriverWait GetWebDriverWait() => new(driver, TimeSpan.FromSeconds(browserSettings.ImplicitWait));
        public Screenshot GetScreenshot() => ((ITakesScreenshot)driver).GetScreenshot();
        public void MoveToElement(BaseElement element)
        {
            var location = element.GetLocation();
            var js = string.Format("window.scrollTo({0}, {1})", location.X, location.Y - 800);
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            javaScriptExecutor.ExecuteScript(js);
        }
        public long GetHeightOfSite()
        {
            var js = string.Format("return document.documentElement.scrollHeight");
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            return (long)javaScriptExecutor.ExecuteScript(js);
        }
    }
}