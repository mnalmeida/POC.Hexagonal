using POC.Hexagonal.Application.Adapters;
using POC.Hexagonal.Application.UseCases.Interfaces;

namespace POC.Hexagonal.Tests.UseCases
{
    public class AtualizarSenhaTest
    {
        private IUsuarioReadDbAdapter _usuarioReadDbAdapter;
        private IUsuarioWriteDbAdapter _usuarioWriteDbAdapter;
        private IAtualizarSenha useCase;
    }
}