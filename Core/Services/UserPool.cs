namespace Core.Services
{
    using Configuration;
    using Models.SingOn;
    using System;
    using System.Collections.Generic;
    using System.Threading.Channels;
    using System.Threading.Tasks;

    public static class UserPool
    {       
        private static Channel<User> boundendChannel;

        public static async Task Initialize()
        {
            var users = new List<User>(JsonDeserializer.DeserializeSectionFromFile<UserRoot>($"settings." +
                $"{Environment.GetEnvironmentVariable("stage")}.json")
                .User.ToArray());
            boundendChannel = Channel.CreateUnbounded<User>();
            foreach (var user in users)
            {
               await boundendChannel.Writer.WriteAsync(user);
            }
        }

        public static async Task<User> GetUserAsync() => await boundendChannel.Reader.ReadAsync();
      
        public static async Task ReturnUserAsync(User user) => await boundendChannel.Writer.WriteAsync(user);

    }
}
