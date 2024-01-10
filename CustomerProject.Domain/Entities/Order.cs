namespace CleanArch.Domain.Entities;

public class Order : BaseEntity
{
    public string OrderNumber { get; set; } = default!;
    public Customer Customer { get; set; } = default!;
    public int CustomerId { get; set; }
}