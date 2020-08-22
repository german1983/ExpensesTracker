using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesTracker.API.Data.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
    }

    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        private readonly string _tableName;

        public BaseEntityConfiguration(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException(nameof(tableName));
            }
            _tableName = tableName;
        }

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(_tableName);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
        }
    }
}
