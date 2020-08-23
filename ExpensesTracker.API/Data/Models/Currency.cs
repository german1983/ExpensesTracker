using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class Currency : BaseEntity
    {
        /// <summary>
        /// Gets or Sets the Name of a Currency
        /// </summary>
        /// <example>US Dollar, Canadian Dollar, Euro, Yuan, etc.</example>
        public string Name { get; set; }

        /// <summary>
        /// Gets of Sets the Code of a Currency
        /// </summary>
        /// <example>USD, CAD, EUR, JPY, etc.</example>
        public string Code { get; set; }

        /// <summary>
        /// Allows navigation to Movements in Operations using this Currency
        /// </summary>
        public virtual IEnumerable<OperationMovement> OperationMovements { get; set; }

        /// <summary>
        /// Allows navigation to Details in Operations using this Currency
        /// </summary>
        public virtual IEnumerable<OperationDetail> OperationDetails { get; set; }
    }

    public class CurrencyEntityConfiguration : BaseEntityConfiguration<Currency>
    {
        public CurrencyEntityConfiguration() : base("Currencies") { }

        public override void Configure(EntityTypeBuilder<Currency> builder)
        {
            base.Configure(builder);
        }
    }
}
