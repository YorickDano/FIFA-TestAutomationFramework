namespace Core.Interfases
{
    using PageObjects;

    public interface ICheckBox
    {
        public void Set(bool state);

        public T Set<T>(bool state) where T : IPageObject;
               
        public bool GetState();
    }
}
