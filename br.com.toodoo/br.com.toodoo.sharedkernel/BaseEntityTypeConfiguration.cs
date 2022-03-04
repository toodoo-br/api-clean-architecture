using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace br.com.toodoo.sharedkernel;

public abstract class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Created).HasColumnName("CriacaoData");
        builder.Property(x => x.CreatedUser).HasColumnName("CriacaoUtilizadorId");
        builder.Property(x => x.Modified).HasColumnName("AlteracaoData").ValueGeneratedOnUpdate();
        builder.Property(x => x.ModifiedUser).HasColumnName("AlteracaoUtilizadorId").ValueGeneratedOnUpdate();
    }
}