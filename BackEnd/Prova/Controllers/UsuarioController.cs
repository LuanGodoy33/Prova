using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prova.Modelos;
using Prova.Repos.Interfaces;

namespace Prova.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepos repository;
        public UsuarioController(IUsuarioRepos _repository)
        {
            repository = _repository;
        }

        [HttpPost("Adicionar/")]
        public async Task<ActionResult<UsuarioModelo>> Adicionar([FromBody] UsuarioModelo usuarioModelo)
        {
            UsuarioModelo usuario = await repository.Adicionar(usuarioModelo);
            return Ok(usuario);
        }

        [HttpPut("Alterar/{id}")]
        public async Task<ActionResult<UsuarioModelo>> Alterar([FromBody] UsuarioModelo usuarioModelo, int id)
        {
            usuarioModelo.Id = id;
            UsuarioModelo usuario = await repository.Alterar(usuarioModelo, id);
            return Ok(usuario);
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<List<UsuarioModelo>>> BuscarPorID(int id)
        {
            UsuarioModelo usuario = await repository.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpGet("BuscarTodos/")]
        public async Task<ActionResult<List<UsuarioModelo>>> BuscarTodosUsuarios()
        {
            List<UsuarioModelo> usuario = await repository.BuscarTodosUsuarios();
            return Ok(usuario);
        }

        [HttpDelete("Deletar/{id}")]
        public async Task<ActionResult<UsuarioModelo>> Deletar(int id)
        {
            bool apagado = await repository.Deletar(id);
            return Ok(apagado);
        }
    }
}
