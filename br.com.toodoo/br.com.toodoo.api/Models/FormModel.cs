namespace br.com.toodoo.api.Models;

public class FormModel : BaseModel
{
    public long? Version { get; set; }
    public string? Name { get; set; }
    public string? FormCode { get; set; }
    public DateTime? DateVersion { get; set; }
    public int? Active { get; set; }
    public string? Notes { get; set; }
    public ICollection<FieldModel>? Fields { get; set; }

}