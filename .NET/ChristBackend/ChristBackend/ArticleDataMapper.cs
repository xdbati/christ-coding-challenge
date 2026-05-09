namespace ChristBackend
{
    /// <summary>
    /// Stores Article Data.
    /// </summary>
    public class ArticleData
    {
        public required string ArticleId { get; set; }
        public required List<ArticleAttributeData> Attributes { get; set; }
    }

    /// <summary>
    /// Stores the specific attributes that make up ArticleData.
    /// </summary>
    public class ArticleAttributeData
    {
        public required string Key { get; set; }
        public required string Value { get; set; }
        public string? Language { get; set; }
    }

    public static class ArticleDataMapper
    {
        /// <summary>
        /// Gets all translations of a given attribute
        /// </summary>
        /// <param name="attributes">List of attributes to check</param>
        /// <param name="key">Key of the attribute</param>
        /// <returns>Dictionary of languages and their translations</returns>
        private static Dictionary<string, string> GetTranslations(List<ArticleAttributeData> attributes, string key)
        {
            return attributes
                .Where(a => a.Key == key && a.Language != null)
                .ToDictionary(a => a.Language!, a => a.Value);
        }

        /// <summary>
        /// Gets values of attributes that do not have a translation
        /// </summary>
        /// <param name="attributes">List of attributes to check</param>
        /// <param name="key">Key of the attribute</param>
        /// <returns>Attribute Value</returns>
        private static string? GetSimple(List<ArticleAttributeData> attributes, string key)
        {
            return attributes.FirstOrDefault(a => a.Key == key && a.Language == null)?.Value;
        }

        /// <summary>
        /// Creates an Article Entry from Article Data
        /// </summary>
        /// <param name="data">Data to map</param>
        /// <returns>Article Entry</returns>
        public static ArticleEntry MapArticleEntry(ArticleData data)
        {
            var attributes = data.Attributes;

            return new ArticleEntry
            {
                ArticleId = data.ArticleId,
                Mrk = GetSimple(attributes, "MRK"),
                Mat = GetTranslations(attributes, "MAT"),
                Mat2 = GetTranslations(attributes, "MAT2"),
                Mat3 = GetTranslations(attributes, "MAT3"),
                Leg = GetTranslations(attributes, "LEG"),
                Leg2 = GetTranslations(attributes, "LEG2"),
                Leg3 = GetTranslations(attributes, "LEG3"),
                Koll = GetSimple(attributes, "KOLL"),
                Wrg2 = GetSimple(attributes, "WRG_2"),
                Whg2 = GetSimple(attributes, "WHG_2"),
                Ziel = GetTranslations(attributes, "ZIEL"),
            };
        }

        public static List<ArticleEntry> MapMultipleArticleEntries(List<ArticleData> datas)
        {
            var output = new List<ArticleEntry>();

            foreach (var data in datas)
            {
                output.Add(MapArticleEntry(data));
            }

            return output;
        }
    }
}
