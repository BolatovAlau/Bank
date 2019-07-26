using Microsoft.EntityFrameworkCore;

namespace Bank.BusinessLogic.Entities
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=trafic.db");
        }

        public DbSet<Batch> Batches { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<SubjectRole> SubjectRoles { get; set; }
        public DbSet<ContractData> ContractDatas { get; set; }
        public DbSet<TotalAmount> TotalAmounts { get; set; }
    }
}
