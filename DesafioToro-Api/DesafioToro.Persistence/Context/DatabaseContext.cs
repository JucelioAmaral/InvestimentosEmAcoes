using DesafioToro.Domain;
using Microsoft.EntityFrameworkCore;

namespace DesafioToro.Persistence.Context
{

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Event> tblEvent { get; set; }
        public DbSet<Origin> tblOrigin { get; set; }
        public DbSet<Target> tblTarget { get; set; }
        public DbSet<Trend> tblTrend { get; set; }
        public DbSet<Order> tblOrder { get; set; }
        public DbSet<User> tblUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
