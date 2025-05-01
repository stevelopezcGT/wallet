namespace Wallet.Domain.Common;

public abstract class EntityBase
{
    [Key]
    [Required(ErrorMessage = "The Id is required")]
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}