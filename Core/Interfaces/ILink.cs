namespace Core.Interfaces
{
    using PageObjects;

    public interface ILink
    {
        public void Click();

        public T Click<T>() where T : IPageObject;

        public string GetValue();

        public string GetUrl();
    }
}
