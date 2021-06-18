using Flunt.Notifications;
using Flunt.Validations;

namespace POC.Hexagonal.Domain.Models
{
    public class Usuario : Notifiable<Notification>
    {
        public Usuario(string cpf, string nome, string email, Senha senha)
        {
            Cpf = cpf;
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public string Cpf { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public Senha Senha { get; private set; }

        public void AtualizarSenha(Senha novaSenha)
        {
            AddNotifications(novaSenha);
            AddNotifications(new Contract<Notification>()
                .Requires()
                .AreNotEquals(novaSenha, Senha, nameof(Senha), "Senha deve ser diferente da atual"));

            Senha = novaSenha;
        }
    }
}