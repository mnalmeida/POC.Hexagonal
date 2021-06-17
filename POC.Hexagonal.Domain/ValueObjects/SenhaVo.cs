using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace POC.Hexagonal.Domain.ValueObjects
{
    public class SenhaVo : Notifiable<Notification>, IEquatable<SenhaVo>
    {
        public string Senha { get; private set; }

        public SenhaVo(string senha)
        {
            Senha = senha;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrWhiteSpace(Senha, nameof(Senha), "Senha não pode ser vazia"));
        }

        public override bool Equals(object? obj) =>
            obj is SenhaVo o && this.Equals(o);

        public bool Equals(SenhaVo other) => this.Senha == other.Senha;
        public override int GetHashCode() => HashCode.Combine(this.Senha);
        public static bool operator ==(SenhaVo left, SenhaVo right) => left.Equals(right);
        public static bool operator !=(SenhaVo left, SenhaVo right) => !(left == right);
    }
}