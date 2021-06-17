using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POC.Hexagonal.Application.Adapters.Commands;
using POC.Hexagonal.Application.Adapters.Queries;
using POC.Hexagonal.DataAccess.CommandsRepositories;
using POC.Hexagonal.DataAccess.QueriesRepositories;

namespace POC.Hexagonal.DataAccess.DependencyInjection
{
    public static class DataAccessCollectionExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUsuarioReadOnlyRepository, UsuarioReadOnlyRepository>();
            services.AddScoped<IUsuarioWriteOnlyRepository, UsuarioWriteOnlyRepository>();
            return services;
        }
    }
}