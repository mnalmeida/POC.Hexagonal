using POC.Hexagonal.Application.InputPorts.Usuario;
using POC.Hexagonal.Application.OutputPorts;

namespace POC.Hexagonal.Application.UseCases.AtualizarSenha
{
    public interface IAtualizarSenhaUseCase
    {
        Result Execute(AtualizarSenhaInput input, string cpf);
    }
}