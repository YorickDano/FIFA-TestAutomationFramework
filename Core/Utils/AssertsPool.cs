namespace Core.Utils
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public static class AssertsPool
    {
        static readonly Dictionary<string, SoftAssertions> pool = new();

        public static void Register()
        {
            pool.Add(TestContext.CurrentContext.Test.ID, new SoftAssertions());
        }

        public static void Verify(Action action) => pool[TestContext.CurrentContext.Test.ID].Verify(action);

        public static void IsPassed() => pool[TestContext.CurrentContext.Test.ID].IsPassed();

        public static bool IsExist(string key) => pool.ContainsKey(key);
    }
}
