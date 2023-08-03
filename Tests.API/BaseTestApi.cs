namespace Tests.API
{
    using Core.Services;
    using Core.Utils;
    using NUnit.Framework;

    public class BaseTestApi
    {
        protected readonly char dirSep = Path.DirectorySeparatorChar;

        [SetUp]
        public void SetUp()
        {
            AssertsPool.Register();
            APIClientPool.CreateAPIClient();
        }

        [TearDown]
        public void TearDown()
        {
            AssertsPool.IsPassed();
            APIClientPool.CloseAPIClient();
        }
    }
}
