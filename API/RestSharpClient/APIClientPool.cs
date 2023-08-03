namespace Core.Services
{
    using Core.Utils;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public static class APIClientPool
    {
        private static readonly Dictionary<string, APIClient> APIClientsPool = new();

        public static void CreateAPIClient()
        {
            APIClientsPool.Add(TestContext.CurrentContext.Test.ID, new APIClient());
            Logger.Info($"APIClient for test with id {TestContext.CurrentContext.Test.ID} was created");
        }

        public static APIClient GetAPIClient()
        {
            if (!APIClientsPool.ContainsKey(TestContext.CurrentContext.Test.ID))
            {
                Logger.Warning($"There is no such APIClient in pool with id: {TestContext.CurrentContext.Test.ID}");
                throw new NullReferenceException("There is no such APIClient with current ID!");
            }
            return APIClientsPool[TestContext.CurrentContext.Test.ID];
        }

        public static void CloseAPIClient()
        {
            var client = APIClientsPool.GetValueOrDefault(TestContext.CurrentContext.Test.ID);
            if(client is null)
            {
                Logger.Warning($"There is no such APIClient in pool with id: {TestContext.CurrentContext.Test.ID}");
                throw new NullReferenceException("There is no such APIClient with current ID!");
            }
            client.Dispose();
            APIClientsPool.Remove(TestContext.CurrentContext.Test.ID);
            Logger.Info($"Closing APIClient with id {TestContext.CurrentContext.Test.ID}");
        }

        public static bool IsExist(string key) =>
            APIClientsPool.ContainsKey(key);
    }
}