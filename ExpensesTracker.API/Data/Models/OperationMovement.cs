using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class OperationMovement : BaseEntity
    {
        public float Amount { get; set; }
        public Guid CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public Guid OperationId { get; set; }
        public virtual Operation Operation { get; set; }

        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
    }

    public class OperationMovementEntityConfiguration : BaseEntityConfiguration<OperationMovement>
    {
        public OperationMovementEntityConfiguration() : base("operationMovements") { }

        public override void Configure(EntityTypeBuilder<OperationMovement> builder)
        {
            base.Configure(builder);

            builder.HasOne(om => om.Account)
               .WithMany(a => a.OperationMovements)
               .HasForeignKey(om => om.AccountId)
               .HasConstraintName("FK_Account_OperationMovements");

            builder.HasOne(om => om.Currency)
               .WithMany(c => c.OperationMovements)
               .HasForeignKey(om => om.CurrencyId)
               .HasConstraintName("FK_Currency_OperationMovements");

            builder.HasOne(om => om.Operation)
                .WithMany(o => o.OperationMovements)
                .HasForeignKey(om => om.OperationId)
                .HasConstraintName("FK_Operation_OperationMovements");

       
        }
    }
}
