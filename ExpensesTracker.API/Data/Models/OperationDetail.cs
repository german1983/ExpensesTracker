using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class OperationDetail : BaseEntity
    {
        /// <summary>
        /// Gets or Sets the Amount of the Operation Detail
        /// </summary>
        public float Amount { get; set; }

        /// <summary>
        /// Gets or Sets the ConceptId
        /// </summary>
        public Guid ConceptId { get; set; }

        /// <summary>
        /// Allows navigation to the Concept to which this Operation Details belongs to
        /// </summary>
        public virtual Concept Concept { get; set; }

        /// <summary>
        /// Gets or Sets the CurrencyId used in the Operation Detail
        /// </summary>
        public Guid CurrencyId { get; set; }

        /// <summary>
        /// Allows navigation to the Currency used in the Operation Detail
        /// </summary>
        public virtual Currency Currency { get; set; }

        /// <summary>
        /// Gets or Sets the OperationId to which this Operation Detail belongs
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Allows navigation to the Operation to which this Operation Detail belongs
        /// </summary>
        public virtual Operation Operation { get; set; }
    }

    public class OperationDetailEntityConfiguration : BaseEntityConfiguration<OperationDetail>
    {
        public OperationDetailEntityConfiguration() : base("OperationDetails") { }

        public override void Configure(EntityTypeBuilder<OperationDetail> builder)
        {
            base.Configure(builder);

            builder.HasOne(od => od.Concept)
               .WithMany(c => c.OperationDetails)
               .HasForeignKey(od => od.ConceptId)
               .HasConstraintName("FK_Category_OperationDetails");

            builder.HasOne(od => od.Currency)
               .WithMany(c => c.OperationDetails)
               .HasForeignKey(od => od.CurrencyId)
               .HasConstraintName("FK_Currency_OperationDetails");

            builder.HasOne(od => od.Operation)
                .WithMany(o => o.OperationDetails)
                .HasForeignKey(od => od.OperationId)
                .HasConstraintName("FK_Operation_OperationDetails");
        }
    }
}
