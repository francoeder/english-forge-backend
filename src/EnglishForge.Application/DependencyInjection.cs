using EnglishForge.Application.Quizzes;
using EnglishForge.Domain.Abstractions.Application;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishForge.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services
                .AddScoped<IQuizzAppService, QuizzAppService>();
        }
    }
}
