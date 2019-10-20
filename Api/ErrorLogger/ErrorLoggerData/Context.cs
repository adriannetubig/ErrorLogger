using ErrorLoggerData.Entitties;
using Microsoft.EntityFrameworkCore;

namespace ErrorLoggerData
{
    public class Context : DbContext
    {
        private readonly string _connectionString;
        public Context(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<EntityExceptionLog> ExceptionLogs { get; set; }
        public DbSet<EntityInnerExceptionLog> InnerExceptionLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EntityExceptionLog>()
                .HasOne(a => a.InnerExceptionLog);

            modelBuilder.Entity<EntityInnerExceptionLog>()
                .Ignore(a => a.ApplicationName);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(_connectionString);
    }
}
