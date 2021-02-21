using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Rise.Assessment.Database
{
    public partial class RiseDbContext : DbContext
    {
        public IConfiguration Configuration { get; private set; }

        public RiseDbContext()
        {
        }

        public RiseDbContext(DbContextOptions<RiseDbContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseNpgsql(Configuration.GetConnectionString("BestLoan"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
