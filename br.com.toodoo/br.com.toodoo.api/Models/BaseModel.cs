namespace br.com.toodoo.api.Models;

public abstract class BaseModel
{
    public long Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public long? CreatedUser { get; set; }
    public long? ModifiedUser { get; set; }
}