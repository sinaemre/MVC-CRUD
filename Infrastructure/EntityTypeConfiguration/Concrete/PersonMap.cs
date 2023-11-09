using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_CRUD.Entities.Concrete;
using MVC_CRUD.Infrastructure.EntityTypeConfiguration.Abstract;

namespace MVC_CRUD.Infrastructure.EntityTypeConfiguration.Concrete
{
    public class PersonMap : BaseMap<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(60).IsRequired(true);
            builder.Property(x => x.Surname).HasMaxLength(60).IsRequired(true);
            builder.Property(x => x.Birthdate).IsRequired(true);
            builder.Property(x => x.Gender).IsRequired(true);

            base.Configure(builder);
        }
    }
}
