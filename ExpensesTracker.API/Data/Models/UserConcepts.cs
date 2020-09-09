using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class UserConcept : BaseEntity
    {
        /// <summary>
        /// Gets or Sets the IdentityId of the User
        /// </summary>
        public Guid IdentityId { get; set; }

        /// <summary>
        /// Gets or Sets the ConceptId
        /// </summary>
        public Guid ConceptId { get; set;}

        /// <summary>
        /// Allows navigation to the Concept referenced by this User Concept
        /// </summary>
        public virtual Concept Concept{ get; set;}
    }

    public class UserConceptEntityConfiguration : BaseEntityConfiguration<UserConcept>
    {
        public UserConceptEntityConfiguration() : base("UserConcepts")
        {
        }

        public  override void Configure(EntityTypeBuilder<UserConcept> builder)
        {
            base.Configure(builder);

            builder.HasOne(uc => uc.Concept)
                .WithMany(c => c.UserConcepts)
                .HasForeignKey(uc => uc.ConceptId)
                .HasConstraintName("FK_Concept_UserConcepts");
        }
    }
}
