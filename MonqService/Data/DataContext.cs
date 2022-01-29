using Microsoft.EntityFrameworkCore;
using MonqService.Models;

namespace MonqService.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Mail> Mails { get; set; }

        public DbSet<Recicpients> Recicpients { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }
    }
}
