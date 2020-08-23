using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class Account : BaseEntity
    {
        /// <summary>
        /// Gets or Sets the Friendly Name of the Account
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the Identity identifier of the owner of the Account
        /// </summary>
        public Guid IdentityId { get; set; }

        /// <summary>
        /// Allows navigation to Movements from Operations using this Account
        /// </summary>
        public virtual IEnumerable<OperationMovement> OperationMovements { get; set; }
    }

    public class AccountEntityConfiguration : BaseEntityConfiguration<Account>
    {
        public AccountEntityConfiguration() : base("Accounts")
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
