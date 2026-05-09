namespace ChristBackend
{
    public class ArticleSyncer : BackgroundService
    {
        private ArticleFetcherService _fetcher;
        private const int increments = 300;

        public ArticleSyncer(ArticleFetcherService fetcher)
        {
            _fetcher = fetcher;
        }

        /// <summary>
        /// Fetches and stores article data in regular intervals until cancelled.
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await _fetcher.FetchAndStore();
                await Task.Delay(TimeSpan.FromSeconds(increments), token);
            }
        }
    }
}
