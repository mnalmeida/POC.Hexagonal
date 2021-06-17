using POC.Hexagonal.Application.OutputPorts.Usuario;

namespace POC.Hexagonal.Application.UseCases.ObterUsuario
{
    public interface IObterUsuarioUseCase
    {
        ObterUsuarioOutput Execute(string cpf);
    }
}
