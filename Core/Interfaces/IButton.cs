namespace Core.Elements
{
    using PageObjects;

    public interface IButton
    {
        public void Click();

        public T Click<T>() where T : IPageObject;

        public string GetValue();

        public string GetTitle();
    }
}
