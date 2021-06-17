using Microsoft.AspNetCore.Mvc;
using POC.Hexagonal.Application.InputPorts.Usuario;
using POC.Hexagonal.Application.OutputPorts.Usuario;
using POC.Hexagonal.Application.UseCases.AtualizarSenha;
using POC.Hexagonal.Application.UseCases.ObterUsuario;

namespace POC.Hexagonal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly IObterUsuarioUseCase _obterUsuarioUseCase;
        private readonly IAtualizarSenhaUseCase _atualizarSenhaUseCase;

        public UsuariosController(IObterUsuarioUseCase obterUsuarioUseCase, IAtualizarSenhaUseCase atualizarSenhaUseCase)
        {
            _obterUsuarioUseCase = obterUsuarioUseCase;
            _atualizarSenhaUseCase = atualizarSenhaUseCase;
        }

        [HttpGet("/{cpf}")]
        [ProducesResponseType(typeof(ObterUsuarioOutput), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult ObterPorCpf([FromRoute] string cpf)
        {
            var usuario = _obterUsuarioUseCase.Execute(cpf);

            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPatch("/{cpf}/senha")]
        [ProducesResponseType(typeof(ObterUsuarioOutput), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult AtualizarSenha([FromBody]AtualizarSenhaInput novaSenha, [FromRoute] string cpf)
        {
            var result = _atualizarSenhaUseCase.Execute(novaSenha, cpf);
            
            if (result.Success) return NoContent();

            return BadRequest(result.Notifications);
        }
    }
}