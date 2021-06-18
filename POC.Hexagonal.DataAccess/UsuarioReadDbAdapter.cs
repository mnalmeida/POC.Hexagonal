using POC.Hexagonal.Application.Adapters;
using POC.Hexagonal.Domain.Models;

namespace POC.Hexagonal.DbAdapter
{
    public class UsuarioReadDbAdapter : IUsuarioReadDbAdapter
    {
        public Usuario Obter(string cpf)
        {
            return new Usuario(cpf, "Usuario de teste", "teste@teste.com", new Senha("545454"));
        }
    }
}