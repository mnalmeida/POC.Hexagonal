using Microsoft.Extensions.Configuration;
using POC.Hexagonal.Application.UseCases;
using POC.Hexagonal.Application.UseCases.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IObterUsuario, ObterUsuario>();
            services.AddScoped<IAtualizarSenha, AtualizarSenha>();
            return services;
        }
    }
}