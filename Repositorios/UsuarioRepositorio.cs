using Microsoft.EntityFrameworkCore;
using SistemadeTarefas.Data;
using SistemadeTarefas.Models;
using SistemadeTarefas.Repositorios.Interfaces;

namespace SistemadeTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
 {
        private readonly SistemaTarefasDBContext _dbContext;
        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            _dbContext = sistemaTarefasDBContext;
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioporId = await BuscarPorId(id);

            if(usuarioporId == null)
            {
                throw new Exception($"Usuario de ID: {id} não foi encontrado");
            }

            usuarioporId.Nome = usuario.Nome;
            usuarioporId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioporId);
            await _dbContext.SaveChangesAsync();

            return usuarioporId;

        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioporId = await BuscarPorId(id);

            if (usuarioporId == null)
            {
                throw new Exception($"Usuario de ID: {id} não foi encontrado");
            }

            _dbContext.Usuarios.Remove(usuarioporId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
