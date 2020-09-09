using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class Operation : BaseEntity
    {
        /// <summary>
        /// Gets or Sets the Date of an Operation
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or Sets the IdentityId of the owner of the operation
        /// </summary>
        public Guid IdentityId { get; set; }

        /// <summary>
        /// Gets or Sets the InstitutionBranchId where this operation has happened
        /// </summary>
        public Guid InstitutionBranchId { get; set; }

        /// <summary>
        /// Allows navigation to the Institution Branch where this operation has happened
        /// </summary>
        public virtual InstitutionBranch InstitutionBranch { get; set; }

        /// <summary>
        /// Allows navigation to the Movements that are part of this Operation
        /// </summary>
        public virtual IEnumerable<OperationMovement> OperationMovements { get; set; }

        /// <summary>
        /// Allows navigation to the Details that form this Operation
        /// </summary>
        public virtual IEnumerable<OperationDetail> OperationDetails { get; set; }
    }

    public class OperationEntityConfiguration : BaseEntityConfiguration<Operation>
    {
        public OperationEntityConfiguration() : base("Operations") { }

        public override void Configure(EntityTypeBuilder<Operation> builder)
        {
            base.Configure(builder);

            builder.HasOne(o => o.InstitutionBranch)
                .WithMany(ib => ib.Operations)
                .HasForeignKey(o => o.InstitutionBranchId)
                .HasConstraintName("FK_Institution_Operations");

            builder.HasIndex(o => o.IdentityId)
                .IsUnique(false);
        }
    }
}
