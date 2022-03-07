using br.com.toodoo.core.FieldAggregate;
using br.com.toodoo.sharedkernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace br.com.toodoo.infrastructure.Database.Configurations;

internal class FieldConfiguration : BaseEntityTypeConfiguration<Field>
{
    public override void Configure(EntityTypeBuilder<Field> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasColumnName("nome");

        builder.Property(x => x.Value)
            .HasColumnName("valor");
    }
}
