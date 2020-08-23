using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class OperationMovement : BaseEntity
    {
        /// <summary>
        /// Gets or Sets the Amount of the Operation Movement
        /// </summary>
        public float Amount { get; set; }

        /// <summary>
        /// Gets or Sets the CurrencyId used in the Operation Movement
        /// </summary>
        public Guid CurrencyId { get; set; }

        /// <summary>
        /// Allows navigation to the Currency used in the Operation Movement
        /// </summary>
        public virtual Currency Currency { get; set; }

        /// <summary>
        /// Gets or Sets the OperationId to which this Operation Movement belongs
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Allows navigation to the Operation to which this Operation Movement belongs
        /// </summary>
        public virtual Operation Operation { get; set; }

        /// <summary>
        /// Gets or Sets the AccountId used in this Operation Movement
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Allows navigation to the Account used in this Operation Movement
        /// </summary>
        public virtual Account Account { get; set; }
    }

    public class OperationMovementEntityConfiguration : BaseEntityConfiguration<OperationMovement>
    {
        public OperationMovementEntityConfiguration() : base("OperationMovements") { }

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
