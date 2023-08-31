using SimulacaoCriptografia.Models;

namespace SimulacaoCriptografia.Respositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario);
        Task<UsuarioModel> AtualizarDadosDoUsuario(UsuarioModel um, int id);
        Task<bool> DeletarUsuario(int id);

    }
}
