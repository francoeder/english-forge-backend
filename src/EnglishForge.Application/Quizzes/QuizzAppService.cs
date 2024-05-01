using System.Text.Json;
using EnglishForge.Domain.Abstractions.Application;
using EnglishForge.Domain.Abstractions.External;
using EnglishForge.Domain.Constants;
using EnglishForge.Domain.Enumerators;
using EnglishForge.Domain.Models.Application;
using EnglishForge.Domain.Models.External.ChatGPT;
using Microsoft.Extensions.Configuration;

namespace EnglishForge.Application.Quizzes
{
    public class QuizzAppService : IQuizzAppService
    {
        private readonly IChatGPTService _chatGPTService;
        private readonly IConfiguration _configuration;

        public QuizzAppService(
            IChatGPTService chatGPTService,
            IConfiguration configuration)
        {
            _chatGPTService = chatGPTService;
            _configuration = configuration;
        }

        public async Task<QuizzModel> GetQuizzAsync(QuestionTypes type, int size, CancellationToken cancellationToken = default)
        {
            var payload = new ChatCompletionInputModel
            {
                Model = _configuration.GetSection("External:ChatGPT:Model").Value,
                Messages =
                [
                    new ChatCompletionMessageModel()
                    {
                        Role = "user",
                        Content = GetPrompt(type, size)
                    }
                ]
            };

            var response = await _chatGPTService.SendChatCompletionAsync(payload, cancellationToken);

            var result = new QuizzModel()
            {
                Type = type,
                Questions = JsonSerializer.Deserialize<List<QuestionModel>>(response.Choices.FirstOrDefault().Message.Content)
            };

            return result;
        }

        private string GetPrompt(QuestionTypes type, int size = 1)
        {
            switch (type)
            {
                case QuestionTypes.VerbConjugation:
                    return string.Format(Prompts.CompleteQuestionListVerbConjugationPrompt, type.GetDescription(), size) +
                        PromptExamples.CompleteQuestionListVerbConjugationExample;
                default:
                    return string.Empty;
            }
        }
    }
}
