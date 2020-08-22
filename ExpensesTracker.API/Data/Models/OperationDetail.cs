using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class OperationDetail : BaseEntity
    {
        public float Amount { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public Guid CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public Guid OperationId { get; set; }
        public virtual Operation Operation { get; set; }
    }

    public class OperationDetailEntityConfiguration : BaseEntityConfiguration<OperationDetail>
    {
        public OperationDetailEntityConfiguration() : base("operationDetails")
        {

        }

        public override void Configure(EntityTypeBuilder<OperationDetail> builder)
        {
            base.Configure(builder);

            builder.HasOne(om => om.Category)
               .WithMany(c => c.OperationDetails)
               .HasForeignKey(om => om.CategoryId)
               .HasConstraintName("FK_Category_OperationDetails");

            builder.HasOne(om => om.Currency)
               .WithMany(c => c.OperationDetails)
               .HasForeignKey(om => om.CurrencyId)
               .HasConstraintName("FK_Currency_OperationDetails");

            builder.HasOne(om => om.Operation)
                .WithMany(o => o.OperationDetails)
                .HasForeignKey(om => om.OperationId)
                .HasConstraintName("FK_Operation_OperationDetails");
        }
    }
}
