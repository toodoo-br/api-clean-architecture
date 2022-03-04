using br.com.toodoo.core.FieldAggregate;
using br.com.toodoo.sharedkernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.toodoo.infrastructure.Database.Configurations
{
    internal class FieldConfiguration : BaseEntityTypeConfiguration<Field>
    {
        public override void Configure(EntityTypeBuilder<Field> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("nome");
            builder.Property(x => x.Value).HasColumnName("valor");
            builder.Property(x => x.FormId).HasColumnName("FormId").IsRequired();
            builder.HasOne(f => f.Form);

        }
    }
}