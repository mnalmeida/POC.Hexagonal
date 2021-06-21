using POC.Hexagonal.Application.Adapters;
using POC.Hexagonal.Application.Ports.Usuario;
using POC.Hexagonal.Application.UseCases.Interfaces;
using POC.Hexagonal.Domain.Exceptions;
using POC.Hexagonal.Domain.Models;

namespace POC.Hexagonal.Application.UseCases
{
    public class AtualizarSenha : IAtualizarSenha
    {
        private readonly IUsuarioReadDbAdapter _usuarioReadDbAdapter;
        private readonly IUsuarioWriteDbAdapter _usuarioWriteDbAdapter;

        public AtualizarSenha(IUsuarioReadDbAdapter usuarioReadDbAdapter,
            IUsuarioWriteDbAdapter usuarioWriteDbAdapter)
        {
            _usuarioReadDbAdapter = usuarioReadDbAdapter;
            _usuarioWriteDbAdapter = usuarioWriteDbAdapter;
        }

        public void Execute(AtualizarSenhaInput input, string cpf)
        {
            Usuario usuario = _usuarioReadDbAdapter.Obter(cpf);

            if(usuario == null)
            {
                throw new DomainException("usuário não existe");
            }

            var novaSenha = new Senha(input.NovaSenha);
            usuario.AtualizarSenha(novaSenha);

            if (!usuario.IsValid)
            {
                throw new NotificationException(usuario.Notifications);
            }

            _usuarioWriteDbAdapter.Atualizar(usuario);
        }
    }
}