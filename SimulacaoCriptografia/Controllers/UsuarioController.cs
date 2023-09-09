using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimulacaoCriptografia.Models;
using SimulacaoCriptografia.Respositorios.Interfaces;

namespace SimulacaoCriptografia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _userRepo;

        public UsuarioController(IUsuarioRepositorio userRepo)
        {
            _userRepo = userRepo;
        }


        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> user = await _userRepo.BuscarTodosUsuarios();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarPorId(int id)
        {
            UsuarioModel user = await _userRepo.BuscarPorId(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<UsuarioModel>>> CadastrarUsuario(UsuarioModel um)
        {
            UsuarioModel user = await _userRepo.AdicionarUsuario(um);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel um, int id)
        {
            um.Id = id;
            UsuarioModel user = await _userRepo.AtualizarDadosDoUsuario(um, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            return Ok(await _userRepo.DeletarUsuario(id));
        }
    }
}
