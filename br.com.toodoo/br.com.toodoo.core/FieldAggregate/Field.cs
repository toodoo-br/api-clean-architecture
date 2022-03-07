using br.com.toodoo.core.FormAggregate;
using br.com.toodoo.sharedkernel;

namespace br.com.toodoo.core.FieldAggregate;

public class Field : BaseEntity
{
    public string? Name { get; set; }
    public string? Value { get; set; }
    public int FormId { get; set; }
    public Form? Form { get; set; }
}

