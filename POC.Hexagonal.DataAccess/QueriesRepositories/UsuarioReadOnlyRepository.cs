using POC.Hexagonal.Application.Adapters.Queries;
using POC.Hexagonal.Domain.Entities;
using POC.Hexagonal.Domain.ValueObjects;

namespace POC.Hexagonal.DataAccess.QueriesRepositories
{
    public class UsuarioReadOnlyRepository : IUsuarioReadOnlyRepository
    {
        public Usuario Obter(string cpf)
        {
            return new Usuario(cpf, "Usuario de teste", "teste@teste.com", new SenhaVo("545454"));
        }
    }
}