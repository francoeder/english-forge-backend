using System.Text.Json.Serialization;

namespace EnglishForge.Domain.Models.External.ChatGPT
{
    public class ChatCompletionMessageModel
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
