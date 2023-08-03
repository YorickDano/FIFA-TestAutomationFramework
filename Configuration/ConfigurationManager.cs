namespace Configuration
{
    using Microsoft.Extensions.Configuration;
    using System;

    public static class ConfigurationManager
    {
        public static T GetConfiguration<T>() where T : class
        {
            string fileName = $"settings.{Environment.GetEnvironmentVariable("stage")}.json";
            var modelObject = Activator.CreateInstance<T>();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(fileName)
                .Build();
            configuration.GetSection(typeof(T).Name).Bind(modelObject);
            return modelObject;
        }
    }
}
