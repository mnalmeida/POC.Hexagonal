using POC.Hexagonal.Domain.Models;
using Xunit;

namespace POC.Hexagonal.Tests.Models
{
    public class UsuarioTest
    {
        [Fact]
        public void CriarUsuario_Valido()
        {
            var usuario = new Usuario("89563632", "Teste", "teste@teste.com", new Senha("teste123"));
            Assert.True(usuario.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("teste123")]
        public void AtualizarSenha_SenhaInvalida(string novaSenha)
        {
            var usuario = new Usuario("89563632", "Teste", "teste@teste.com", new Senha("teste123"));

            usuario.AtualizarSenha(new Senha(novaSenha));

            Assert.False(usuario.IsValid);
            Assert.Contains(usuario.Notifications, n => n.Key == nameof(Usuario.Senha));
        }

        [Fact]
        public void AtualizarSenha_SenhaValida()
        {
            var usuario = new Usuario("89563632", "Teste", "teste@teste.com", new Senha("teste123"));

            usuario.AtualizarSenha(new Senha("abc8899"));

            Assert.True(usuario.IsValid);
        }
    }
}
