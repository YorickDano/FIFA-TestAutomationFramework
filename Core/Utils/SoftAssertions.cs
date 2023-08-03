namespace Core.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoftAssertions
    {
        private readonly List<Exception> info = new();
        public void Verify(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                info.Add(ex);
            }
        }

        public void IsPassed()
        {
            var failed = info.Count();

            if(failed > 0)
            {
                throw new AggregateException(info);
            }
        }
    }
}
