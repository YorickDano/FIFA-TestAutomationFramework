namespace Core.Interfaces
{
    using PageObjects;

    public interface ITextBox
    {
        public void SendKeys(string text);
        public T SendKeys<T>(string text) where T : IPageObject;
        public string GetValue();
        public string GetValueOfAttribute(string attribute);
    }
}
