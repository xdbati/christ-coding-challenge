using System.Text.Json.Serialization;

namespace ChristBackend
{
    /// <summary>
    /// Contains all relevant data for an article entry in order to be saved into stroage.
    /// </summary>
    public class ArticleEntry
    {
        /***
         * In order to display different translations of article attributes,
         * the corresponding translations are saved if applicable.
         */

        [JsonPropertyName("articleId")] public required string ArticleId { get; set; }          // Id
        [JsonPropertyName("MRK")] public string? Mrk { get; set; }                              // Brand Name
        [JsonPropertyName("MAT")] public Dictionary<string, string> Mat { get; set; } = [];     // Material 1
        [JsonPropertyName("MAT2")] public Dictionary<string, string> Mat2 { get; set; } = [];   // Material 2
        [JsonPropertyName("MAT3")] public Dictionary<string, string> Mat3 { get; set; } = [];   // Material 3
        [JsonPropertyName("LEG")] public Dictionary<string, string> Leg { get; set; } = [];     // Alloy 1
        [JsonPropertyName("LEG2")] public Dictionary<string, string> Leg2 { get; set; } = [];   // Alloy 2
        [JsonPropertyName("LEG3")] public Dictionary<string, string> Leg3 { get; set; } = [];   // Alloy 3
        [JsonPropertyName("KOLL")] public string? Koll { get; set; }                            // Collection
        [JsonPropertyName("WRG_2")] public string? Wrg2 { get; set; }                           // Product Group
        [JsonPropertyName("WHG_2")] public string? Whg2 { get; set; }                           // Main Product Group
        [JsonPropertyName("ZIEL")] public Dictionary<string, string> Ziel { get; set; } = [];   // Target Group
    }
}
