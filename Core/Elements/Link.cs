namespace Core.Elements
{
    using Core.Interfaces;
    using Core.Utils;
    using OpenQA.Selenium;
    using PageObjects;
    using System;

    public class Link : BaseElement, ILink
    {
        public Link(IWebElement element, string name) : base(element, name) { }

        public void Click()
        {
            Element.Click();
            Logger.Info($"Link '{Name}' was clicked");
        }

        public T Click<T>() where T : IPageObject
        {
            Click();
            return Activator.CreateInstance<T>();
        }

        public string GetValue() => Element.Text;

        public string GetUrl() => Element.GetAttribute("href");

    }
}