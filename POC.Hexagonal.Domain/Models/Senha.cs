using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace POC.Hexagonal.Domain.Models
{
    public class Senha : Notifiable<Notification>, IEquatable<Senha>
    {
        public string Valor { get; private set; }

        public Senha(string senha)
        {
            Valor = senha;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrWhiteSpace(Valor, nameof(Senha), "Senha não pode ser vazia"));
        }

        public override bool Equals(object? obj) => obj is Senha o && this.Equals(o);
        public bool Equals(Senha other) => this.Valor == other.Valor;
        public override int GetHashCode() => HashCode.Combine(this.Valor);
        public static bool operator ==(Senha left, Senha right) => left.Equals(right);
        public static bool operator !=(Senha left, Senha right) => !(left == right);
    }
}