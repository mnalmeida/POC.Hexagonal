using Moq;
using POC.Hexagonal.Application.Adapters;
using POC.Hexagonal.Application.Ports.Usuario;
using POC.Hexagonal.Application.UseCases;
using POC.Hexagonal.Application.UseCases.Interfaces;
using POC.Hexagonal.Domain.Exceptions;
using POC.Hexagonal.Domain.Models;
using Xunit;

namespace POC.Hexagonal.Tests.UseCases
{
    public class AtualizarSenhaTest
    {
        private Mock<IUsuarioReadDbAdapter> _usuarioReadDbAdapter;
        private Mock<IUsuarioWriteDbAdapter> _usuarioWriteDbAdapter;
        private IAtualizarSenha useCase;

        private void Setup()
        {
            _usuarioReadDbAdapter = new Mock<IUsuarioReadDbAdapter>();
            _usuarioWriteDbAdapter = new Mock<IUsuarioWriteDbAdapter>();
            useCase = new AtualizarSenha(_usuarioReadDbAdapter.Object, _usuarioWriteDbAdapter.Object);
    }

        [Fact]
        public void AtualizarSenha_UsuarioNaoEncontrado()
        {
            Setup();
            _usuarioReadDbAdapter.Setup(mock => mock.Obter(It.IsAny<string>())).Returns<Usuario>(null);

            Assert.Throws<DomainException>(() => useCase.Execute(new AtualizarSenhaInput() { NovaSenha = "4525" }, "045896321456"));

            _usuarioReadDbAdapter.Verify(mock => mock.Obter("045896321456"), Times.Once);
            _usuarioWriteDbAdapter.VerifyNoOtherCalls();
        }

        [Fact]
        public void AtualizarSenha_SenhaInvalida()
        {
            Setup();
            string cpf = "045896321456";
            _usuarioReadDbAdapter.Setup(mock => mock.Obter(cpf))
                .Returns(new Usuario(cpf, "Usuario de teste", "teste@teste.com", new Senha("8989")));

            Assert.Throws<NotificationException>(() => useCase.Execute(new AtualizarSenhaInput() { NovaSenha = "8989" }, cpf));

            _usuarioReadDbAdapter.Verify(mock => mock.Obter(cpf), Times.Once);
            _usuarioWriteDbAdapter.VerifyNoOtherCalls();
        }

        [Fact]
        public void AtualizarSenha_Sucesso()
        {
            Setup();
            string cpf = "045896321456";
            Usuario usuarioMock = new Usuario(cpf, "Usuario de teste", "teste@teste.com", new Senha("962222"));
            _usuarioReadDbAdapter.Setup(mock => mock.Obter(cpf)).Returns(usuarioMock);

            useCase.Execute(new AtualizarSenhaInput() { NovaSenha = "8989" }, cpf);

            _usuarioReadDbAdapter.Verify(mock => mock.Obter(cpf), Times.Once);
            _usuarioWriteDbAdapter.Verify(mock => mock.Atualizar(It.Is<Usuario>(p =>
                    p.Email == usuarioMock.Email &&
                    p.Cpf == usuarioMock.Cpf &&
                    p.Nome == usuarioMock.Nome &&
                    p.Senha == new Senha("8989"))), Times.Once);
        }
    }
}