using System.ComponentModel.DataAnnotations;

namespace br.com.toodoo.api.Models;

public class FieldModel : BaseModel
{
    public string? Name { get; set; }
    public string? Value { get; set; }
    public long FormId { get; set; }

    [ScaffoldColumn(false)]
    public string FormName { get; set; }
}
