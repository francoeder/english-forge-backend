using System.Text.Json.Serialization;

namespace EnglishForge.Domain.Models.Application
{
    public class QuestionModel
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("fullTitle")]
        public string FullTitle { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("options")]
        public List<Option> Options { get; set; }
    }

    public class Option
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("isCorrect")]
        public bool IsCorrect { get; set; }
    }
}
