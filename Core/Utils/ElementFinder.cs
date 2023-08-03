namespace Core.Utils
{
    using Core.Elements;
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static Core.Services.BrowserPool;

    public static class ElementFinder
    {
        public static T Get<T>(By locator, string elementName="") where T : BaseElement
        {             
            return (T)Activator.CreateInstance(typeof(T), GetBrowser().FindElement(locator), elementName);
        }
 
        public static IEnumerable<T> GetElements<T>(By locator, string elementName = "") where T : BaseElement
        {
            return GetBrowser().FindElements(locator).Select(el => (T)Activator.CreateInstance(typeof(T), el, elementName));
        }
    }
}
