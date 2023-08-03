namespace Tests.UI
{
    using Configuration;
    using Core.Services;
    using Core.Utils;
    using Models.BrowserSettings;
    using NUnit.Framework;

    [TestFixture]
    [Parallelizable(scope: ParallelScope.All)]
    public class BaseTest
    {
        protected BrowserSettingsModel Settings => ConfigurationManager.GetConfiguration<BrowserSettingsModel>();

        [SetUp]
        public void SetUp()
        {
            BrowserPool.CreateBrowser();
            BrowserPool.GetBrowser().OpenInFullScreen();
            AssertsPool.Register();
        }

        [TearDown]
        public void TearDown()
        {
            AssertsPool.IsPassed();
            BrowserPool.CloseBrowser();
        }
    }

}