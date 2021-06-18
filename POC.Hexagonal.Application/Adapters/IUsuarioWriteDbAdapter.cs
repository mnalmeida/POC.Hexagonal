using POC.Hexagonal.Domain.Models;

namespace POC.Hexagonal.Application.Adapters
{
    public interface IUsuarioWriteDbAdapter
    {
        void Atualizar(Usuario usuario);
    }
}