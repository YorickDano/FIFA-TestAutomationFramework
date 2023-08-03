namespace Core.Elements
{
    using Core.Interfaces;
    using Core.Utils;
    using OpenQA.Selenium;
    using PageObjects;
    using System;

    public class Textbox : BaseElement, ITextBox
    {
        public Textbox(IWebElement element, string name) : base(element, name) { }

        public void SendKeys(string text)
        {
            Element.SendKeys(text);
            Logger.Info($"Text was sended to '{Name}' TextBox");
        }

        public T SendKeys<T>(string text) where T : IPageObject
        {
            SendKeys(text);
            return Activator.CreateInstance<T>();
        }

        public string GetValue() => Element.Text;
        public string GetValueOfAttribute(string attribute) => Element.GetAttribute(attribute);
    }
}
