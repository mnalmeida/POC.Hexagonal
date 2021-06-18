using Microsoft.Extensions.Configuration;
using POC.Hexagonal.Application.Adapters;
using POC.Hexagonal.DbAdapter;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DataAccessCollectionExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUsuarioReadDbAdapter, UsuarioReadDbAdapter>();
            services.AddScoped<IUsuarioWriteDbAdapter, UsuarioWriteDbAdapter>();
            return services;
        }
    }
}