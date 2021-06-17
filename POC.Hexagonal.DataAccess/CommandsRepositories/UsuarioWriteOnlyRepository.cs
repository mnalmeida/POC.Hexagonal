using POC.Hexagonal.Application.Adapters.Commands;
using POC.Hexagonal.Domain.Entities;

namespace POC.Hexagonal.DataAccess.CommandsRepositories
{
    public class UsuarioWriteOnlyRepository : IUsuarioWriteOnlyRepository
    {
        public void Atualizar(Usuario usuario)
        {
            //atualizar usuario no banco
        }
    }
}