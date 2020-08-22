using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class UserCategory : BaseEntity
    {
        public Guid IdentityId { get; set; }
        public Guid CategoryId { get; set;}
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
                .WithMany(i => i.UserCategories)
                .HasForeignKey(ui => ui.CategoryId)
                .HasConstraintName("FK_Category_UserCategories");
        }
    }
}
