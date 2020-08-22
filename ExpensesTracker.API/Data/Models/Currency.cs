using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class Currency : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual IEnumerable<OperationMovement> OperationMovements { get; set; }
        public virtual IEnumerable<OperationDetail> OperationDetails { get; set; }
    }

    public class CurrencyEntityConfiguration : BaseEntityConfiguration<Currency>
    {
        public CurrencyEntityConfiguration() : base("currencies") { }

        public override void Configure(EntityTypeBuilder<Currency> builder)
        {
            base.Configure(builder);
        }
    }
}
