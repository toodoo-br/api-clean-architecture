namespace br.com.toodoo.sharedkernel;

public abstract class BaseEntity
{
    public long Id { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Modified { get; set; }
    public long? CreatedUser { get; set; }
    public long? ModifiedUser { get; set; }
}