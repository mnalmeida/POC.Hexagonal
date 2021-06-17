using POC.Hexagonal.Domain.Entities;

namespace POC.Hexagonal.Application.Adapters.Commands
{
    public interface IUsuarioWriteOnlyRepository
    {
        void Atualizar(Usuario usuario);
    }
}