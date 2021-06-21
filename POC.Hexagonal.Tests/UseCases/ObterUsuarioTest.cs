using Moq;
using POC.Hexagonal.Application.Adapters;
using POC.Hexagonal.Application.UseCases;
using POC.Hexagonal.Application.UseCases.Interfaces;
using POC.Hexagonal.Domain.Models;
using Xunit;

namespace POC.Hexagonal.Tests.UseCases
{
    public class ObterUsuarioTest
    {
        private Mock<IUsuarioReadDbAdapter> _usuarioReadDbAdapter;
        private IObterUsuario useCase;

        private void Setup()
        {
            _usuarioReadDbAdapter = new Mock<IUsuarioReadDbAdapter>();
            useCase = new ObterUsuario(_usuarioReadDbAdapter.Object);
        }

        [Fact]
        public void ObterUsuario_UsuarioNaoEncontrado()
        {
            Setup();
            _usuarioReadDbAdapter.Setup(mock => mock.Obter(It.IsAny<string>())).Returns<Usuario>(null);

            var retorno = useCase.Execute("25653232323");

            _usuarioReadDbAdapter.Verify(mock => mock.Obter("25653232323"), Times.Once);
            Assert.Null(retorno);
        }

        [Fact]
        public void ObterUsuario_Sucesso()
        {
            Setup();
            string cpf = "045896321456";
            var usuarioMock = new Usuario(cpf, "Usuario de teste", "teste@teste.com", new Senha("8989"));
            _usuarioReadDbAdapter.Setup(mock => mock.Obter(cpf)).Returns(usuarioMock);

            var retorno = useCase.Execute(cpf);

            _usuarioReadDbAdapter.Verify(mock => mock.Obter(cpf), Times.Once);
            Assert.NotNull(retorno);
            Assert.Equal(usuarioMock.Cpf, retorno.Cpf);
            Assert.Equal(usuarioMock.Email, retorno.Email);
            Assert.Equal(usuarioMock.Nome, retorno.Nome);
        }
    }
}