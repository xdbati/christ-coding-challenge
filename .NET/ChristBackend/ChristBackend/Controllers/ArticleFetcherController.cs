using Microsoft.AspNetCore.Mvc;

namespace ChristBackend.Controllers
{
    [ApiController]
    [Route("api/articles")]
    public class ArticleFetcherController : ControllerBase
    {
        private readonly ArticleDataService _articleDataService;

        public ArticleFetcherController(ArticleDataService articleDataService)
        {
            _articleDataService = articleDataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStoredArticles()
        {
            var entries = await _articleDataService.ReadAll();
            if (entries == null || entries.Count == 0)
                return NotFound();
            return Ok(entries);
        }
    }
}
