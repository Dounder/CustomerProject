using CleanArch.Application.Common.DTOs;

namespace CleanArch.Application.UseCases.Orders.DTOs;

public class OrderDto : BaseDto
{
    public string OrderNumber { get; set; }
}

public class CreateOrderDto
{
    public string OrderNumber { get; set; } = default!;
}