using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rise.Assessment.Log4netDatabase.Entities;

namespace Rise.Assessment.Log4netDatabase
{
    public partial class Log4netContext : DbContext
    {
        public IConfiguration Configuration { get; private set; }


        protected Log4netContext()
        {
        }

        public Log4netContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        public virtual DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Configuration.GetConnectionString("log4net"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Thread).HasMaxLength(255);
                entity.Property(e => e.Level).HasMaxLength(50);
                entity.Property(e => e.Logger).HasMaxLength(255);
                entity.Property(e => e.Message).HasMaxLength(4000);
                entity.Property(e => e.Exception).HasMaxLength(2000).IsRequired(false);
            });
        }
    }
}
