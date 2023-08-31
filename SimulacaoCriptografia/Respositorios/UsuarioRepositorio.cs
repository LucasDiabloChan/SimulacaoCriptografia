using Microsoft.EntityFrameworkCore;
using SimulacaoCriptografia.Data;
using SimulacaoCriptografia.Models;
using SimulacaoCriptografia.Respositorios.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace SimulacaoCriptografia.Respositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaDeTarefasBDContext _dbContext;

        public UsuarioRepositorio(SistemaDeTarefasBDContext sistemaTarefaDBContext)
        {
            _dbContext = sistemaTarefaDBContext;
        }


        // INSERE um usuário no banco
        public async Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario); // Adiciona o user
            await _dbContext.SaveChangesAsync(); // Salva as alterações no BD

            return usuario;
        }


        // Buscar TODOS usuários
        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }


        // Buscar usuário por: ID
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }


        // ATUALIZAR dados do usuário
        public async Task<UsuarioModel> AtualizarDadosDoUsuario(UsuarioModel um, int id)
        {
            UsuarioModel usuarioEncontrado = await BuscarPorId(id);

            if (usuarioEncontrado == null)
            {
                throw new Exception($"O usuário com Id '{id}' não foi encontrado.");
            }

            usuarioEncontrado.Nome = um.Nome;
            usuarioEncontrado.Email = um.Email;

            _dbContext.Usuarios.Update(usuarioEncontrado);
            await _dbContext.SaveChangesAsync();

            return usuarioEncontrado;
        }


        // REMOVER usuário do banco
        public async Task<bool> DeletarUsuario(int id)
        {
            UsuarioModel um = await BuscarPorId(id);

            if( um == null)
            {
                throw new Exception($"Não foi possível encontrar um usuário com id '{id}'.");
            }

            _dbContext.Usuarios.Remove(um);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
