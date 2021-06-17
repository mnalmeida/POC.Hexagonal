using Flunt.Notifications;
using POC.Hexagonal.Application.Adapters.Commands;
using POC.Hexagonal.Application.Adapters.Queries;
using POC.Hexagonal.Application.InputPorts.Usuario;
using POC.Hexagonal.Application.OutputPorts;
using POC.Hexagonal.Domain.Entities;
using POC.Hexagonal.Domain.ValueObjects;

namespace POC.Hexagonal.Application.UseCases.AtualizarSenha
{
    public class AtualizarSenhaUseCase : Notifiable<Notification>, IAtualizarSenhaUseCase
    {
        private readonly IUsuarioReadOnlyRepository _usuarioReadOnlyRepository;
        private readonly IUsuarioWriteOnlyRepository _usuarioWriteOnlyRepository;

        public AtualizarSenhaUseCase(IUsuarioReadOnlyRepository usuarioReadOnlyRepository,
            IUsuarioWriteOnlyRepository usuarioWriteOnlyRepository)
        {
            _usuarioReadOnlyRepository = usuarioReadOnlyRepository;
            _usuarioWriteOnlyRepository = usuarioWriteOnlyRepository;
        }

        public Result Execute(AtualizarSenhaInput input, string cpf)
        {
            Usuario usuario = _usuarioReadOnlyRepository.Obter(cpf);

            if(usuario == null)
            {
                AddNotification("teste", "teste");
                return Result.Error(Notifications);
            }

            var novaSenha = new SenhaVo(input.NovaSenha);
            usuario.AtualizarSenha(novaSenha);

            if (usuario.IsValid)
            {
                _usuarioWriteOnlyRepository.Atualizar(usuario);
            }
            return Result.Error(usuario.Notifications);
        }
    }
}