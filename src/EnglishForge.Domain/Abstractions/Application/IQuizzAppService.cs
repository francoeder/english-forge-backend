using EnglishForge.Domain.Enumerators;
using EnglishForge.Domain.Models.Application;

namespace EnglishForge.Domain.Abstractions.Application
{
    public interface IQuizzAppService
    {
        Task<QuizzModel> GetQuizzAsync(QuestionTypes type, int size, CancellationToken cancellationToken = default);
    }
}
