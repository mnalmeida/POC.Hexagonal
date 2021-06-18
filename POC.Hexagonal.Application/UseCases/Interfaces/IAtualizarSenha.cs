using POC.Hexagonal.Application.Ports.Usuario;

namespace POC.Hexagonal.Application.UseCases.Interfaces
{
    public interface IAtualizarSenha
    {
        void Execute(AtualizarSenhaInput input, string cpf);
    }
}