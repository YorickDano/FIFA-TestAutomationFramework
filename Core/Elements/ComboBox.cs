namespace Core.Elements
{
    using Core.Interfaces;
    using Core.Utils;
    using OpenQA.Selenium;
    using PageObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ComboBox : BaseElement, IComboBox
    {
        public ComboBox(IWebElement element, string name) : base(element, name) { }

        public List<string> GetList() =>
            Element.FindElements(By.XPath("//option")).Select(x => x.Text).ToList();

        public void ClickOn(string item)
        {
            Element.FindElement(By.XPath($"//*[contains(text(),'{item}')]")).Click();
            Logger.Info($"Element '{Name}' from ComboBox was clicked ");
        }

        public T ClickOn<T>(string item) where T : IPageObject
        {
            ClickOn(item);
            return Activator.CreateInstance<T>();
        }

    }
}