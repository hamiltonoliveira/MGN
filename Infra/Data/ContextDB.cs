using System.Threading.Tasks;
using Applicationcore.Entities;
using Applicationcore.UnitOfWork;
using Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public  class ContextDB : DbContext, IUnitOfWork
    {
        public ContextDB(DbContextOptions<ContextDB> options)
        : base(options)
        {}

        public DbSet<Client> Clients { get; set; }
        public DbSet<Phone> Prones { get; set; }
        public DbSet<Adress> Adresses { get; set; }

        public async Task SalvarBco()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new AdressMap());
            modelBuilder.ApplyConfiguration(new PhoneMap());
        }

    }
}
