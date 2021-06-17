using POC.Hexagonal.Domain.Entities;
using POC.Hexagonal.Domain.ValueObjects;
using Xunit;

namespace POC.Hexagonal.Tests.Entities
{
    public class UsuarioTest
    {
        [Fact]
        public void CriarUsuario_Valido()
        {
            var usuario = new Usuario("89563632", "Teste", "teste@teste.com", new SenhaVo("teste123"));
            Assert.True(usuario.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("teste123")]
        public void AtualizarSenha_SenhaInvalida_Test(string novaSenha)
        {
            var usuario = new Usuario("89563632", "Teste", "teste@teste.com", new SenhaVo("teste123"));

            usuario.AtualizarSenha(new SenhaVo(novaSenha));

            Assert.False(usuario.IsValid);
            Assert.Contains(usuario.Notifications, n => n.Key == nameof(Usuario.Senha));
        }

        [Fact]
        public void AtualizarSenha_SenhaValida_Test()
        {
            var usuario = new Usuario("89563632", "Teste", "teste@teste.com", new SenhaVo("teste123"));

            usuario.AtualizarSenha(new SenhaVo("abc8899"));

            Assert.True(usuario.IsValid);
        }
    }
}
