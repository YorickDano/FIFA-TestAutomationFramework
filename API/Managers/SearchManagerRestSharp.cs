namespace Core.API.Managers
{
    using Core.Services;
    using Models.API.ApiSearch;
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class SearchManagerRestSharp
    {
        public async static Task<RestResponse> ExecuteGetRequestForSearch(string configurationDataFullPath)
        {
            var configurationData = JsonDeserializer.DeserializeSectionFromFile<FifaSearchApi>(configurationDataFullPath);

            RequestBuilder requestBuilder = new RequestBuilder();

            requestBuilder.CreateRequest()
                .SetRequestResource("search")
                .AddRequestParameter("searchString", configurationData.SearchString)
                .AddRequestParameter("page", configurationData.Page)
                .AddRequestParameter("pageSize", configurationData.PageSize)
                .AddRequestParameter("contentType", configurationData.ContentType)
                .AddRequestParameter("sort", configurationData.Sort)
                .AddRequestParameter("dateFrom", configurationData.DateFrom)
                .AddRequestParameter("locale", configurationData.Locale)
                .SetRequestMethod(Method.Get);

            var res = await APIClientPool.GetAPIClient().ExecuteAsync(requestBuilder.GetRequest());
            return res;
        }
    }
}
