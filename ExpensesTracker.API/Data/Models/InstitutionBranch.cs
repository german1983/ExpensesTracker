using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class InstitutionBranch : BaseEntity
    {
        public string Name { get; set; }

        public Guid InstitutionId { get; set; }
        public virtual Institution Institution { get; set;}
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
