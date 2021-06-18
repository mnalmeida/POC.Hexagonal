using Microsoft.AspNetCore.Mvc;
using POC.Hexagonal.Application.Ports.Usuario;
using POC.Hexagonal.Application.UseCases.Interfaces;

namespace POC.Hexagonal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly IObterUsuario _obterUsuario;
        private readonly IAtualizarSenha _atualizarSenha;

        public UsuariosController(IObterUsuario obterUsuario, IAtualizarSenha atualizarSenha)
        {
            _obterUsuario = obterUsuario;
            _atualizarSenha = atualizarSenha;
        }

        [HttpGet("/{cpf}")]
        [ProducesResponseType(typeof(ObterUsuarioOutput), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult ObterPorCpf([FromRoute] string cpf)
        {
            var usuario = _obterUsuario.Execute(cpf);

            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPatch("/{cpf}/senha")]
        [ProducesResponseType(typeof(ObterUsuarioOutput), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult AtualizarSenha([FromBody]AtualizarSenhaInput novaSenha, [FromRoute] string cpf)
        {
            _atualizarSenha.Execute(novaSenha, cpf);
            
            return NoContent();

            //return BadRequest(result.Notifications);
        }
    }
}