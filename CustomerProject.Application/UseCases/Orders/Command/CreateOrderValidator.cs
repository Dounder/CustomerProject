using CleanArch.Application.UseCases.Orders.DTOs;
using FluentValidation;

namespace CleanArch.Application.UseCases.Orders.Command;

public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer Id is required");
        RuleFor(x => x.Orders).NotEmpty().WithMessage("Orders is required");
        RuleForEach(x => x.Orders).SetValidator(new CreateOrderDtoValidator());
    }
}

public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        RuleFor(x => x.OrderNumber).NotEmpty().WithMessage("Order Number is required");
    }
}