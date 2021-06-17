using Flunt.Notifications;
using POC.Hexagonal.Application.Adapters.Queries;
using POC.Hexagonal.Application.OutputPorts.Usuario;

namespace POC.Hexagonal.Application.UseCases.ObterUsuario
{
    public class ObterUsuarioUseCase : Notifiable<Notification>, IObterUsuarioUseCase
    {
        private readonly IUsuarioReadOnlyRepository _usuarioReadOnlyRepository;

        public ObterUsuarioUseCase(IUsuarioReadOnlyRepository usuarioReadOnlyRepository)
        {
            _usuarioReadOnlyRepository = usuarioReadOnlyRepository;
        }

        public ObterUsuarioOutput Execute(string cpf)
        {
            var usuario = _usuarioReadOnlyRepository.Obter(cpf);

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