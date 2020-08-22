using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class UserInstitutionBranch : BaseEntity
    {
        public Guid IdentityId { get; set; }
        public Guid InstitutionBranchId {get; set;}
        public virtual InstitutionBranch InstitutionBranch { get; set;}
    }

    public class UserInstitutionBranchEntityConfiguration : BaseEntityConfiguration<UserInstitutionBranch>
    {
        public UserInstitutionBranchEntityConfiguration() : base("UserInstitutionBranches")
        {
        }

        public  override void Configure(EntityTypeBuilder<UserInstitutionBranch> builder)
        {
            base.Configure(builder);

            builder.HasOne(ui => ui.InstitutionBranch)
                .WithMany(i => i.UserInstitutionBranches)
                .HasForeignKey(ui => ui.InstitutionBranchId)
                .HasConstraintName("FK_InstitutionBranch_UserInstitutionBranches");
                
        }
    }
}
