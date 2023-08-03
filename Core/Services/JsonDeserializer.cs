namespace Core.Services
{
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System;
    using System.IO;

    public static class JsonDeserializer
    {
        public static T DeserializeFromFile<T>(string fileFullPath) => JsonConvert.DeserializeObject<T>(File.ReadAllText(fileFullPath));

        public static T DeserializeFromString<T>(string jsonString) => JsonConvert.DeserializeObject<T>(jsonString);

        public static T DeserializeSectionFromFile<T>(string fileFullPath) where T : class
        {
            var modelObject = Activator.CreateInstance<T>();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(fileFullPath)
                .Build();
            configuration.GetSection(typeof(T).Name).Bind(modelObject);
            return modelObject;
        }
    }
}
