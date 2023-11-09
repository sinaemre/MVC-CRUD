using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_CRUD.Entities.Abstract;

namespace MVC_CRUD.Infrastructure.EntityTypeConfiguration.Abstract
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedDate)
                   .HasColumnName("CreateDate")
                   .HasColumnType("datetime2")
                   .IsRequired(true);

            builder.Property(x => x.UpdatedDate)
                   .HasColumnName("UpdateDate")
                   .HasColumnType("datetime2")
                   .IsRequired(false);

            builder.Property(x => x.DeletedDate)
                   .HasColumnName("DeleteDate")
                   .HasColumnType("datetime2")
                   .IsRequired(false);

            builder.Property(x => x.Status)
                   .HasColumnName("Status")
                   .IsRequired(true);
        }
    }
}
