using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rise.Assessment.Database.Entities;

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

        public virtual DbSet<ContactInfo> ContactInfos { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Report> Reports { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseNpgsql(Configuration.GetConnectionString("Rise"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
