using Microsoft.EntityFrameworkCore;
using FFinder.Core;

namespace FFinder.Infra
{
    public class FriendContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=DBTeste;Trusted_Connection=True;");
        }

        public DbSet<Friend> Friend { get; set; }
        public DbSet<CalculoHistoricoLog> CalculoHistoricoLog { get; set; }
        
    }
}
