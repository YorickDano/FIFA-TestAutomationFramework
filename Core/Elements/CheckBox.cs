namespace Core.Elements
{
    using Core.Interfases;
    using Core.Utils;
    using OpenQA.Selenium;
    using PageObjects;
    using System;

    public class CheckBox : BaseElement, ICheckBox
    {
        public CheckBox(IWebElement element, string name) : base(element, name) { }

        public void Set(bool state)
        {
            if (state != (Element.GetAttribute("aria-checked") == "true"))
            {
                Element.Click();
                Logger.Info($"CheckBox '{Name}' was changed");
            }
        }

        public T Set<T>(bool state) where T : IPageObject
        {
            Set(state);
            return Activator.CreateInstance<T>();
        }

        public bool GetState() => Element.GetAttribute("aria-checked") == "true";

    }
}