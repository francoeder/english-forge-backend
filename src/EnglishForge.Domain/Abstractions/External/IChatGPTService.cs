using EnglishForge.Domain.Models.External.ChatGPT;

namespace EnglishForge.Domain.Abstractions.External
{
    public interface IChatGPTService
    {
        Task<ChatCompletionOutputModel> SendChatCompletionAsync(ChatCompletionInputModel payload, CancellationToken cancellationToken = default);
    }
}
