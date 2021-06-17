using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POC.Hexagonal.Application.UseCases.AtualizarSenha;
using POC.Hexagonal.Application.UseCases.ObterUsuario;

namespace POC.Hexagonal.Application.DependencyInjection
{
    public static class ApplicationCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IObterUsuarioUseCase, ObterUsuarioUseCase>();
            services.AddScoped<IAtualizarSenhaUseCase, AtualizarSenhaUseCase>();
            return services;
        }
    }
}