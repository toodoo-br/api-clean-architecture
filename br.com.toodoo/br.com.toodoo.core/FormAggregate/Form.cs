using br.com.toodoo.core.FieldAggregate;
using br.com.toodoo.sharedkernel;

namespace br.com.toodoo.core.FormAggregate;

public class Form : BaseEntity
{
    public long? Version { get; set; }
    public string? Name { get; set; }
    public string? FormCode { get; set; }
    public DateTime? DateVersion { get; set; }
    public int? Active { get; set; }
    public string? Notes { get; set; }
    public ICollection<Field>? Fields { get; set; }
}