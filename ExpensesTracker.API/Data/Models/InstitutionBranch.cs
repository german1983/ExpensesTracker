using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class InstitutionBranch : BaseEntity
    {
        /// <summary>
        /// Gets or Sets the Name of an Insitution Branch
        /// </summary>
        /// <example>Billings Bridge, Trainyard, etc</example>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the InstitutionId
        /// </summary>
        public Guid InstitutionId { get; set; }

        /// <summary>
        /// Allows navigation to the Institution
        /// </summary>
        public virtual Institution Institution { get; set;}

        /// <summary>
        /// Allows navigation to Operations that have been registered in this Institution Branch
        /// </summary>
        public virtual IEnumerable<Operation> Operations { get; set; }

        /// <summary>
        /// Allows navigation to Users using this Institution Branch
        /// </summary>
        public virtual IEnumerable<UserInstitutionBranch> UserInstitutionBranches { get; set; }

    }

    public class InstitutionBranchEntityConfiguration : BaseEntityConfiguration<InstitutionBranch>
    {
        public InstitutionBranchEntityConfiguration() : base("InstitutionBranches") { }

        public override void Configure(EntityTypeBuilder<InstitutionBranch> builder)
        {
            base.Configure(builder);

            builder.HasOne(ib => ib.Institution)
                .WithMany(i => i.InstitutionBranches)
                .HasForeignKey(ib => ib.InstitutionId)
                .HasConstraintName("FK_Institution_InstitutionBranches");
        }
    }
}
