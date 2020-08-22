using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<OperationDetail> OperationDetails { get; set; }
        public Guid? CategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual IEnumerable<Category> ChildrenCategories { get; set; }
        public virtual IEnumerable<UserCategory> UserCategories { get; set; }
    }

    public class CategoryEntityConfiguration : BaseEntityConfiguration<Category>
    {
        public CategoryEntityConfiguration() : base("categories") { }

        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
        }
    }
}
