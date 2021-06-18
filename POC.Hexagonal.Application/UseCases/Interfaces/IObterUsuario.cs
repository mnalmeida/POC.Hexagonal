using POC.Hexagonal.Application.Ports.Usuario;

namespace POC.Hexagonal.Application.UseCases.Interfaces
{
    public interface IObterUsuario
    {
        ObterUsuarioOutput Execute(string cpf);
    }
}