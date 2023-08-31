using Microsoft.EntityFrameworkCore;
using SimulacaoCriptografia.Data.Map;
using SimulacaoCriptografia.Models;

namespace SimulacaoCriptografia.Data
{
    public class SistemaDeTarefasBDContext : DbContext
    {
        public SistemaDeTarefasBDContext(DbContextOptions<SistemaDeTarefasBDContext> opts) 
            : base(opts)
        {
            
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfiguration(new UsuarioMap());
            mb.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(mb);
        }
    }
}
