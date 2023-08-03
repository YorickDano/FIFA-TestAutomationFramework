namespace Core.Services
{
    using Configuration;
    using Models.API;
    using RestSharp;
    using System;
    using System.Threading.Tasks;

    public class APIClient : IDisposable
    {
        private static readonly object Locker = new();
        private static RestClient Client;
        private static RestClient GetClient {
            get
            {
                lock (Locker)
                {
                    if (Client == null)
                    {
                        Client = new RestClient();
                    }
                    return Client;
                }
            }
        }
        private readonly ApiSettingsModel ApiClientSettings;
        public APIClient()
        {
            ApiClientSettings = ConfigurationManager.GetConfiguration<ApiSettingsModel>();
            var options = new RestClientOptions
            {
                BaseUrl = new Uri(ApiClientSettings.BaseUrl),
                Timeout = ApiClientSettings.Timeout
            };
            Client = new RestClient(options);
        }

        public async Task<RestResponse> ExecuteAsync(RestRequest request) =>
            await GetClient.ExecuteAsync(request);

        public void Dispose()
        {
            if (Client == null)
            {
                throw new NullReferenceException("client have a null reference");
            }
            Client.Dispose();
        } 
    }
}
