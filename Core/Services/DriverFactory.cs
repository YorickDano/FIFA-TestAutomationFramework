namespace Core.Services
{
    using Models.BrowserSettings;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Remote;
    using System;
    using System.Collections.Generic;
    using static Configuration.ConfigurationManager;

    internal static class DriverFactory
    {
        public static IWebDriver GetDriver(string browserType = "chrome")
        {
            IWebDriver driver;
            var browserStack = GetConfiguration<BrowserStack>();
            Dictionary<string, object> browserstackOptions = new();

            browserstackOptions.Add("os", "Windows");
            browserstackOptions.Add("osVersion", "10");
            browserstackOptions.Add("userName", browserStack.userName);
            browserstackOptions.Add("accessKey", browserStack.accessKey);

            switch (browserType.ToLower())
            {
                 case "firefox":
                     {
                         var firefoxCapability = new FirefoxOptions();
                         firefoxCapability.BrowserVersion = "latest";
                         firefoxCapability.AddAdditionalOption("bstack:options", browserstackOptions);
                         driver = new RemoteWebDriver(new Uri(browserStack.url), firefoxCapability);
                         break;
                     }
                 case "edge":
                     {
                         var edgeCapability = new EdgeOptions();
                         edgeCapability.BrowserVersion = "latest";
                         edgeCapability.AddAdditionalOption("bstack:options", browserstackOptions);
                         driver = new RemoteWebDriver(new Uri(browserStack.url), edgeCapability);
                         break;
                     }
                 case "chrome":
                     {
                         var chromeCapability = new ChromeOptions();
                         chromeCapability.BrowserVersion = "latest";
                         chromeCapability.AddAdditionalOption("bstack:options", browserstackOptions);
                         driver = new ChromeDriver();
                         break;
                     }
                 default:
                     {
                        throw new ArgumentException("Incorrect browser value!");
                     }
            }
            return driver;
        }
    }
}
