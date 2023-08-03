namespace Core.Elements
{
    using Core.Utils;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using PageObjects;
    using System;

    public class Button : BaseElement, IButton
    {
        public Button(IWebElement element, string name) : base(element, name) { }

        public void Click()
        {
            Element.Click();
            Logger.Info($"Button '{Name}' was clicked");
        }

        public T Click<T>() where T : IPageObject
        {
            Click();
            return Activator.CreateInstance<T>();
        }

        public string GetValue() =>
            Element.Text == "" ? Element.GetAttribute("value") : Element.Text;

        public string GetTitle() => Element.GetAttribute("title");
    }
}