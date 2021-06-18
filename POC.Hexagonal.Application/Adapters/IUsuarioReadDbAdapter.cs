using POC.Hexagonal.Domain.Models;

namespace POC.Hexagonal.Application.Adapters
{
    public interface IUsuarioReadDbAdapter
    {
        Usuario Obter(string cpf);
    }
}