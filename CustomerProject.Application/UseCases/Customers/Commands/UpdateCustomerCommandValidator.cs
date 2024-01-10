using AutoMapper;
using CleanArch.Domain.Exceptions;
using CleanArch.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace CleanArch.Application.UseCases.Customers.Commands;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");

        RuleFor(x => x.Name)
            .MinimumLength(2).WithMessage("Name must have at least 2 characters")
            .MaximumLength(100).WithMessage("Name must have a maximum of 100 characters");
    }
}