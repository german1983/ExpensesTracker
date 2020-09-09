using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class UserInstitutionBranch : BaseEntity
    {
        /// <summary>
        /// Gets or Sets the IdentityId of the User
        /// </summary>
        public Guid IdentityId { get; set; }

        /// <summary>
        /// Gets or Sets the InstitutionBranchId
        /// </summary>
        public Guid InstitutionBranchId {get; set;}

        /// <summary>
        /// Allows navigation to the Institution Branch referenced by this User Institution Branch
        /// </summary>
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
