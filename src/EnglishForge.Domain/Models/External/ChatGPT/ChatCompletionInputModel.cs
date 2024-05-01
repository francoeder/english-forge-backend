using System.Text.Json.Serialization;

namespace EnglishForge.Domain.Models.External.ChatGPT
{
    public class ChatCompletionInputModel
    {
        [JsonPropertyName("messages")]
        public List<ChatCompletionMessageModel> Messages { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }
    }
}
