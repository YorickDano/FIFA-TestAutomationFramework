namespace Core.Interfaces
{
    using PageObjects;
    using System.Collections.Generic;

    public interface IComboBox
    {
        public List<string> GetList();

        public void ClickOn(string item);

        public T ClickOn<T>(string item) where T : IPageObject;
    }
}
