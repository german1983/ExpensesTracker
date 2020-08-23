using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class UserInstitution : BaseEntity
    {
        /// <summary>
        /// Gets or Sets the IdentityId of the User
        /// </summary>
        public Guid IdentityId { get; set; }

        /// <summary>
        /// Gets or Sets the InstitutionId
        /// </summary>
        public Guid InstitutionId {get; set;}

        /// <summary>
        /// Allows navigation to the Institution referenced by this User Institution
        /// </summary>
        public virtual Institution Institution { get; set;}
    }

    public class UserInstitutionEntityConfiguration : BaseEntityConfiguration<UserInstitution>
    {
        public UserInstitutionEntityConfiguration() : base("UserInstitutions")
        {
        }

        public  override void Configure(EntityTypeBuilder<UserInstitution> builder)
        {
            base.Configure(builder);

            builder.HasOne(ui => ui.Institution)
                .WithMany(i => i.UserInstitutions)
                .HasForeignKey(ui => ui.InstitutionId)
                .HasConstraintName("FK_Institution_UserInstitutions");
                
        }
    }
}
