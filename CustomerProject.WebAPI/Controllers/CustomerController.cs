using CleanArch.Application.UseCases.Customers.Commands;
using CleanArch.Application.UseCases.Customers.Queries;
using CleanArch.Application.UseCases.Orders.Command;
using CleanArch.Application.UseCases.Orders.Queries;
using CleanArch.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Controllers;

[Route("api/customer")]
public class CustomerController(IMediator mediator) : BaseController
{
    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] PaginationParams pagination) => Ok(await mediator.Send(new GetCustomersQuery(pagination)));

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var query = new GetCustomerByIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id:int}/orders")]
    public async Task<ActionResult> GetOrders(int id, [FromQuery] PaginationParams pagination)
    {
        var query = new GetCustomerOrdersQuery(id, pagination);
        return Ok(await mediator.Send(query));
    }

    [HttpPost]
    public async Task<ActionResult> Post(CreateCustomerCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(new
        {
            message = "Customer created successfully",
            data = result
        });
    }

    [HttpPost("orders")]
    public async Task<ActionResult> Post(CreateOrderCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(new
        {
            message = "Orders has been created",
            data = result
        });
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, UpdateCustomerCommand command)
    {
        if (id != command.Id) return BadRequest(new { message = "Id is not valid" });

        await mediator.Send(command);
        return Ok(new { message = "Customer updated successfully" });
    }

    [HttpPut("{id:int}/activate")]
    public async Task<ActionResult> Put(int id)
    {
        await mediator.Send(new ActivateCustomerCommand(id));
        return Ok(new { message = "Customer activated successfully" });
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteCustomerCommand(id));
        return Ok(new { message = "Customer deleted successfully" });
    }
}