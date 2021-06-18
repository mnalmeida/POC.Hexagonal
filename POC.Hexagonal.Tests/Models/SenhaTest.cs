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
        public void CriarSenha_Invalido_Test(string senha)
        {
            var senhaVo = new Senha(senha);

            Assert.False(senhaVo.IsValid);
            Assert.Contains(senhaVo.Notifications, n => n.Key == nameof(senhaVo.Valor));
        }

        [Fact]
        public void CriarSenha_Valido_Test()
        {
            var senhaVo = new Senha("teste123");

            Assert.True(senhaVo.IsValid);
        }
    }
}