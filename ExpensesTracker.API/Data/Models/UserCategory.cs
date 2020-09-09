using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class UserCategory : BaseEntity
    {
        /// <summary>
        /// Gets or Sets the IdentityId of the User
        /// </summary>
        public Guid IdentityId { get; set; }

        /// <summary>
        /// Gets or Sets the CategoryId
        /// </summary>
        public Guid CategoryId { get; set;}

        /// <summary>
        /// Allows navigation to the Category referenced by this User Category
        /// </summary>
        public virtual Category Category { get; set;}
    }

    public class UserCategoryEntityConfiguration : BaseEntityConfiguration<UserCategory>
    {
        public UserCategoryEntityConfiguration() : base("UserCategories")
        {
        }

        public  override void Configure(EntityTypeBuilder<UserCategory> builder)
        {
            base.Configure(builder);

            builder.HasOne(ui => ui.Category)
                .WithMany(c => c.UserCategories)
                .HasForeignKey(ui => ui.CategoryId)
                .HasConstraintName("FK_Category_UserCategories");
        }
    }
}
