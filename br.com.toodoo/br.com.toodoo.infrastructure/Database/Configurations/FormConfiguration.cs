using br.com.toodoo.core.FormAggregate;
using br.com.toodoo.sharedkernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace br.com.toodoo.infrastructure.Database.Configurations;

internal class FormConfiguration : BaseEntityTypeConfiguration<Form>
{
    public override void Configure(EntityTypeBuilder<Form> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();
        builder.Property(x => x.Version).HasColumnName("versao");
        builder.Property(x => x.Name).HasColumnName("nome");
        builder.Property(x => x.FormCode).HasColumnName("codigo_formulario");
        builder.Property(x => x.DateVersion).HasColumnName("data_versao");
        builder.Property(x => x.Active).HasColumnName("activo");
        builder.Property(x => x.Notes).HasColumnName("observacoes");
    }
}