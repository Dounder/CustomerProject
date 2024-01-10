using System.ComponentModel.DataAnnotations;

namespace CleanArch.Domain.Entities;

public class Customer : BaseEntity
{
    public string Name { get; set; } = null!;

    public HashSet<Order> Orders { get; set; } = new();
}