using Flunt.Notifications;
using Flunt.Validations;
using POC.Hexagonal.Domain.ValueObjects;

namespace POC.Hexagonal.Domain.Entities
{
    public class Usuario : Notifiable<Notification>
    {
        public Usuario(string cpf, string nome, string email, SenhaVo senha)
        {
            Cpf = cpf;
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public string Cpf { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public SenhaVo Senha { get; private set; }

        public void AtualizarSenha(SenhaVo novaSenha)
        {
            AddNotifications(novaSenha);
            AddNotifications(new Contract<Notification>()
                .Requires()
                .AreNotEquals(novaSenha, Senha, nameof(Senha), "Senha deve ser diferente da atual"));

            Senha = novaSenha;
        }
    }
}