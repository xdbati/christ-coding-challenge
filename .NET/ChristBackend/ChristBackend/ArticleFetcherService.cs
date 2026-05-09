using System.Text.Json;

namespace ChristBackend
{
    public class ArticleFetcherService
    {
        private const string URL = "https://christ-coding-challenge.test.pub.k8s.christ.de/Article/GetArticles";

        private readonly ArticleDataService _articleDataService;
        private static readonly JsonSerializerOptions fetchOptions = new() { PropertyNameCaseInsensitive = true };

        private readonly HttpClient _httpClient;

        public ArticleFetcherService(HttpClient httpClient, ArticleDataService articleDataService)
        {
            _httpClient = httpClient;
            _articleDataService = articleDataService;
        }

        public async Task FetchAndStore()
        {
            var json = await _httpClient.GetStringAsync(URL);
            var entries = JsonSerializer.Deserialize<List<ArticleData>>(json, fetchOptions) ?? new();
            var mapped = ArticleDataMapper.MapMultipleArticleEntries(entries);

            _articleDataService.Upsert(mapped);
        }
    }
}
