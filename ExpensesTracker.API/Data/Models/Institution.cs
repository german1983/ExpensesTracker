using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class Institution : BaseEntity
    {
        public string Name { get; set; }
        public virtual IEnumerable<Operation> Operations { get; set; }
        public virtual IEnumerable<UserInstitution> UserInstitutions { get; set; }
        public virtual IEnumerable<InstitutionBranch> InstitutionBranches { get; set; }

    }

    public class InstitutionEntityConfiguration : BaseEntityConfiguration<Institution>
    {
        public InstitutionEntityConfiguration() : base("institutions")
        {

        }

        public override void Configure(EntityTypeBuilder<Institution> builder)
        {
            base.Configure(builder);
        }
    }
}
