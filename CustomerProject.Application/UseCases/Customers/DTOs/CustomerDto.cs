using CleanArch.Application.Common.DTOs;
using CleanArch.Application.UseCases.Orders.DTOs;

namespace CleanArch.Application.UseCases.Customers.DTOs;

public class CustomerDto : BaseDto
{
    public string Name { get; set; }
}

public class CustomerWithOrdersDto : CustomerDto
{
    public List<OrderDto> Orders { get; set; } = new();
}