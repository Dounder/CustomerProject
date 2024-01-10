using CleanArch.Domain.Interfaces;

namespace CleanArch.Domain.Entities;

public class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}