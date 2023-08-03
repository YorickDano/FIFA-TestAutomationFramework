namespace Core.Services
{
    using Core.Utils;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public static class BrowserPool
    {
        private static readonly Dictionary<string, Browser> browsersPool = new();

        public static void CreateBrowser()
        {
            browsersPool.Add(TestContext.CurrentContext.Test.ID, new Browser());
            Logger.Info($"Browser for test with id {TestContext.CurrentContext.Test.ID} was created");
        }
        public static Browser GetBrowser()
        {
            if (!browsersPool.ContainsKey(TestContext.CurrentContext.Test.ID))
            {
                Logger.Warning($"There is no such browser in pool with id: {TestContext.CurrentContext.Test.ID}");
                throw new NullReferenceException("There is no such browser with current ID!");
            }
            return browsersPool[TestContext.CurrentContext.Test.ID]; 
        }
        public static void CloseBrowser()
        {
            var browser = browsersPool[TestContext.CurrentContext.Test.ID];
            if (browser == null)
            {
                Logger.Warning($"There is no such browser in pool with id: {TestContext.CurrentContext.Test.ID}");
                throw new NullReferenceException("There is no such browser with current ID!");
            }
            browser.Dispose();
            browsersPool.Remove(TestContext.CurrentContext.Test.ID);
            Logger.Info($"Closing browser with id {TestContext.CurrentContext.Test.ID}");
        }

        public static bool IsExist(string key) =>
            browsersPool.ContainsKey(key);
    }
}