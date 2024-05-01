using EnglishForge.Domain.Abstractions.External;
using EnglishForge.Domain.Models.External.ChatGPT;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EnglishForge.Infrastructure.External.ChatGPT
{
    public class ChatGPTService : IChatGPTService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ChatGPTService> _logger;

        public ChatGPTService(
            IConfiguration configuration,
            ILogger<ChatGPTService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<ChatCompletionOutputModel> SendChatCompletionAsync(ChatCompletionInputModel payload, CancellationToken cancellationToken = default)
        {
            try
            {
                var baseUrl = _configuration.GetSection("External:ChatGPT:BaseUrl").Value;

                var response = await baseUrl
                    .AppendPathSegments("v1", "chat", "completions")
                    .WithHeader("Authorization", GetAuthorizationHeader())
                    .PostJsonAsync(payload, default, cancellationToken)
                    .ReceiveJson<ChatCompletionOutputModel>();

                return response;
            }
            catch (FlurlHttpException ex)
            {
                var error = await ex.GetResponseStringAsync();
                _logger.LogError(ex, error);
                throw;
            }
        }

        private string GetAuthorizationHeader()
        {
            var authorization = $"Bearer {_configuration.GetSection("External:ChatGPT:ApiKey").Value}";
            return authorization;
        }
    }
}
