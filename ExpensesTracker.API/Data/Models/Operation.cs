using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class Operation : BaseEntity
    {
        public DateTime Date { get; set; }
        public Guid IdentityId { get; set; }

        public Guid InstitutionId { get; set; }
        public virtual Institution Institution { get; set; }

        public virtual IEnumerable<OperationMovement> OperationMovements { get; set; }
        public virtual IEnumerable<OperationDetail> OperationDetails { get; set; }
    }

    public class OperationEntityConfiguration : BaseEntityConfiguration<Operation>
    {
        public OperationEntityConfiguration() : base("operations")
        {

        }

        public override void Configure(EntityTypeBuilder<Operation> builder)
        {
            base.Configure(builder);

            builder.HasOne(o => o.Institution)
                .WithMany(i => i.Operations)
                .HasForeignKey(o => o.InstitutionId)
                .HasConstraintName("FK_Institution_Operations");


            builder.HasIndex(o => o.IdentityId)
                .IsUnique(false);
        }
    }
}
