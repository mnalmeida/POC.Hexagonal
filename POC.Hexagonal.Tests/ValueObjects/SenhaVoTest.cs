using POC.Hexagonal.Domain.ValueObjects;
using Xunit;

namespace POC.Hexagonal.Tests.ValueObjects
{
    public class SenhaVoTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void CriarSenha_Invalido_Test(string senha)
        {
            var senhaVo = new SenhaVo(senha);

            Assert.False(senhaVo.IsValid);
            Assert.Contains(senhaVo.Notifications, n => n.Key == nameof(senhaVo.Senha));
        }

        [Fact]
        public void CriarSenha_Valido_Test()
        {
            var senhaVo = new SenhaVo("teste123");

            Assert.True(senhaVo.IsValid);
        }
    }
}