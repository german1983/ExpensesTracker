using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class Account : BaseEntity
    {
        public string Name { get; set; }
        public Guid IdentityId { get; set; }
        public virtual IEnumerable<OperationMovement> OperationMovements { get; set; }
    }

    public class AccountEntityConfiguration : BaseEntityConfiguration<Account>
    {
        public AccountEntityConfiguration() : base("accounts")
        {

        }

        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);

            builder.HasIndex(a => a.IdentityId)
                .IsUnique(false);
        }
    }

}
