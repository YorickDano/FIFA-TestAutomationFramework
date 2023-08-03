namespace Core.Elements
{
    using OpenQA.Selenium;
    using System.Drawing;

    public class BaseElement
    {
        public IWebElement Element { get; set; }
        public string Name { get; set; }

        public BaseElement(IWebElement element, string name)
        {
            Element = element;
            Name = name;
        }

        public Point GetLocation() => Element.Location;

        public Size GetSize() => Element.Size;

    }
}
