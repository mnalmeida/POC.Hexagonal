using POC.Hexagonal.Application.Adapters;
using POC.Hexagonal.Application.Ports.Usuario;
using POC.Hexagonal.Application.UseCases.Interfaces;

namespace POC.Hexagonal.Application.UseCases
{
    public class ObterUsuario : IObterUsuario
    {
        private readonly IUsuarioReadDbAdapter _usuarioReadDbAdapter;

        public ObterUsuario(IUsuarioReadDbAdapter usuarioReadDbAdapter)
        {
            _usuarioReadDbAdapter = usuarioReadDbAdapter;
        }

        public ObterUsuarioOutput Execute(string cpf)
        {
            var usuario = _usuarioReadDbAdapter.Obter(cpf);

            if (usuario == null) return null;

            return new ObterUsuarioOutput()
            {
                Cpf = usuario.Cpf,
                Email = usuario.Email,
                Nome = usuario.Nome
            };
        }
    }
}