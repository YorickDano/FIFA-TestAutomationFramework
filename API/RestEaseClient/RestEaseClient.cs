namespace Core.API.RestEaseClient
{
    using RestEase;
    using System.Threading.Tasks;

    public class RestEaseClient
    {

        [Header("User-Agent", "RestEase")]
        public interface IFifaSearchApi
        {
            [Get("search")]
            public Task<string> Get(
                [Query("searchString")] string searchString,
                [Query("page")] string page,
                [Query("pageSize")] string pageSize,
                [Query("contentType")] string contentType,
                [Query("sort")] string sort,
                [Query("dateFrom")] string dateFrom,
                [Query("locale")] string locale
                );
        }
    }
}