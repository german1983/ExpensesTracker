using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class Category : BaseEntity
    {
        /// <summary>
        /// Gets or Sets the Category Name
        /// </summary>
        /// <example>Wage, Basics, Housing, etc.</example>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the IsPublic flag of the Category
        /// </summary>
        /// <value>
        ///  <see langword="true"/> if this Category is available to all users in the system; otherwise, <see langword="false"/> if it's a Custom Category created by a User
        /// </value>
        public bool IsPublic { get; set; }

        /// <summary>
        /// Gets or Sets the Parent Category
        /// </summary>
        /// <remarks>
        /// Optional
        /// </remarks>
        public Guid? ParentCategoryId { get; set; }

        /// <summary>
        /// Allows navigation to Parent Category
        /// </summary>
        public virtual Category ParentCategory { get; set; }

        /// <summary>
        /// Allows navigation to Concepts using this Category
        /// </summary>
        public virtual IEnumerable<Concept> Concepts { get; set; }

        /// <summary>
        /// Allows navigation to Categories under this Category
        /// </summary>
        public virtual IEnumerable<Category> ChildrenCategories { get; set; }

        /// <summary>
        /// Allows navigation to Users using this Category
        /// </summary>
        public virtual IEnumerable<UserCategory> UserCategories { get; set; }
    }

    public class CategoryEntityConfiguration : BaseEntityConfiguration<Category>
    {
        public CategoryEntityConfiguration() : base("Categories") { }

        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
        }
    }
}
