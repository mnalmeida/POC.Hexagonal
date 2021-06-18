using POC.Hexagonal.Application.Adapters;
using POC.Hexagonal.Domain.Models;

namespace POC.Hexagonal.DbAdapter
{
    public class UsuarioWriteDbAdapter : IUsuarioWriteDbAdapter
    {
        public void Atualizar(Usuario usuario)
        {
            //atualizar usuario no banco
        }
    }
}