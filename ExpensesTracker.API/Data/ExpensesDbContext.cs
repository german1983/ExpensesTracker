using ExpensesTracker.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesTracker.API.Data
{
    public class ExpensesDbContext : DbContext
    {
        public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options) : base(options)
        {

        }

        #region DbSets
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Concept> Concepts { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<InstitutionBranch> InstitutionBranches { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationDetail> OperationDetails { get; set; }
        public DbSet<OperationMovement> OperationMovements { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
        public DbSet<UserConcept> UserConcepts { get; set; }
        public DbSet<UserInstitution> UserInstitutions { get; set; }
        public DbSet<UserInstitutionBranch> UserInstitutionBranches { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ConceptEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InstitutionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InstitutionBranchEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OperationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OperationDetailEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OperationMovementEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserCategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserCategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserInstitutionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserInstitutionBranchEntityConfiguration());
        }
    }
}
