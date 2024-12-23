using Microsoft.EntityFrameworkCore;
using SistemadeTarefas.Data;
using SistemadeTarefas.Models;
using SistemadeTarefas.Repositorios.Interfaces;

namespace SistemadeTarefas.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
 {
        private readonly SistemaTarefasDBContext _dbContext;
        public TarefaRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            _dbContext = sistemaTarefasDBContext;
        }
        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _dbContext.Tarefa
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefa
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _dbContext.Tarefa.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();

            return tarefa;
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaporId = await BuscarPorId(id);

            if(tarefaporId == null)
            {
                throw new Exception($"Tarefa de ID: {id} não foi encontrado");
            }

            tarefaporId.Nome = tarefa.Nome;
            tarefaporId.Descricao = tarefa.Descricao;
            tarefaporId.Status = tarefa.Status;
            tarefaporId.UsuarioId = tarefa.UsuarioId;

            _dbContext.Tarefa.Update(tarefaporId);
            await _dbContext.SaveChangesAsync();

            return tarefaporId; 

        }

        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaporId = await BuscarPorId(id);

            if (tarefaporId == null)
            {
                throw new Exception($"Tarefa de ID: {id} não foi encontrado");
            }

            _dbContext.Tarefa.Remove(tarefaporId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
