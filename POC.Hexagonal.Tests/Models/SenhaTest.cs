using POC.Hexagonal.Domain.Models;
using Xunit;

namespace POC.Hexagonal.Tests.Models
{
    public class SenhaTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void CriarSenha_Invalido(string senha)
        {
            var senhaVo = new Senha(senha);

            Assert.False(senhaVo.IsValid);
            Assert.Contains(senhaVo.Notifications, n => n.Key == "Senha");
        }

        [Fact]
        public void CriarSenha_Valido()
        {
            var senhaVo = new Senha("teste123");

            Assert.True(senhaVo.IsValid);
        }
    }
}