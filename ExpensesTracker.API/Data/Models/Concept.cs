using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class Concept : BaseEntity
    {
        /// <summary>
        /// Gets or Sets the Description of the Concept
        /// </summary>
        /// <example>Rent, Salary, Dairy Products, etc.</example>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the IsPublic flag of the Concept
        /// </summary>
        /// <value>
        ///  <see langword="true"/> if this Concept is available to all users in the system; otherwise, <see langword="false"/> if it's a Custom Concept created by a User
        /// </value>
        public bool IsPublic { get; set; }

        /// <summary>
        /// Gets or Sets the CategoryId
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Allows navigation to the Category of the Concept
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// Allows navigation to Users using this Concept
        /// </summary>
        public virtual IEnumerable<UserConcept> UserConcepts { get; set; }

        /// <summary>
        /// Allows navigation to Details of Operations using this Concept
        /// </summary>
        public virtual IEnumerable<OperationDetail> OperationDetails { get; set; }
    }

    public class ConceptEntityConfiguration : BaseEntityConfiguration<Concept>
    {
        public ConceptEntityConfiguration() : base("Concepts") { }

        public override void Configure(EntityTypeBuilder<Concept> builder)
        {
            base.Configure(builder);

            builder.HasOne(c => c.Category)
                .WithMany(c => c.Concepts)
                .HasForeignKey(c => c.CategoryId)
                .HasConstraintName("FK_Category_Concepts");
        }
    }
}
