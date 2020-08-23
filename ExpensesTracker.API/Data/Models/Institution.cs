using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class Institution : BaseEntity
    {
        /// <summary>
        /// Gets or Sets the Name of an Insitution
        /// </summary>
        /// <example>Walmart, Starbucks, etc</example>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the IsPublic flag of the Institution
        /// </summary>
        /// <value>
        ///  <see langword="true"/> if this Institution is available to all users in the system; otherwise, <see langword="false"/> if it's a Custom Institution created by a User
        /// </value>
        public bool IsPublic { get; set; }

        /// <summary>
        /// Allows navigation to Users using this Institution
        /// </summary>
        public virtual IEnumerable<UserInstitution> UserInstitutions { get; set; }

        /// <summary>
        /// Allows navigation to the List of Branches of this institution
        /// </summary>
        public virtual IEnumerable<InstitutionBranch> InstitutionBranches { get; set; }

    }

    public class InstitutionEntityConfiguration : BaseEntityConfiguration<Institution>
    {
        public InstitutionEntityConfiguration() : base("Institutions")
        {

        }

        public override void Configure(EntityTypeBuilder<Institution> builder)
        {
            base.Configure(builder);
        }
    }
}
