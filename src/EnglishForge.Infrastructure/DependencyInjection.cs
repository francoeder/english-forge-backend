using EnglishForge.Domain.Abstractions.External;
using EnglishForge.Infrastructure.External.ChatGPT;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishForge.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services
                .AddScoped<IChatGPTService, ChatGPTService>();
        }
    }
}
