using System.Text.Json;

namespace ChristBackend
{
    /// <summary>
    /// This deals with saving and loading article entries into persistent storage (JSON).
    /// </summary>
    public class ArticleDataService
    {
        private const string FILE_PATH = "articles.json";
        private static readonly SemaphoreSlim _lock = new(1, 1);

        /// <summary>
        /// Reads and returns all available article data from persistent storage.
        /// </summary>
        /// <returns>List of article entries from persistent storage.</returns>
        public async Task<List<ArticleEntry>> ReadAll()
        {
            await _lock.WaitAsync();
            try
            {
                if (!File.Exists(FILE_PATH)) 
                    return new List<ArticleEntry>();
                return JsonSerializer.Deserialize<List<ArticleEntry>>(File.ReadAllText(FILE_PATH)) ?? new();
            }
            finally
            {
                _lock.Release();
            }
        }

        /// <summary>
        /// Saves all given article entries into persistent storage.
        /// </summary>
        /// <param name="entries">Entries to save.</param>
        public async void SaveAll(List<ArticleEntry> entries)
        {
            await _lock.WaitAsync();
            try
            {
                if (File.Exists(FILE_PATH))
                    File.Delete(FILE_PATH);

                File.WriteAllText(FILE_PATH, JsonSerializer.Serialize(entries));
            }
            finally
            {
                _lock.Release();
            }
        }

        /// <summary>
        /// Upserts given article entries into persistent storage.
        /// </summary>
        /// <param name="newEntries">Entries to upsert.</param>
        public async void Upsert(List<ArticleEntry> newEntries)
        {
            var entries = await ReadAll();

            foreach (var article in newEntries)
            {
                var index = entries.FindIndex(a => a.ArticleId == article.ArticleId);
                if (index < 0)
                    entries.Add(article);
                else
                    entries[index] = article;
            }

            SaveAll(entries);
        }
    }
}
