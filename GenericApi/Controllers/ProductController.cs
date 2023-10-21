using Application.Behavior;
using Application.Commands;
using Domain.Dtos;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GenericApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    [HttpPost(Name = "createProducts")]
    public async Task<IActionResult> Post([FromBody] CreateProductCommand command, [FromServices] IMediator _mediator)
    {
        try
        {
            ProductDto result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (CustomValidationException ex)
        {
            var errorResponse = new { ex.Status, ex.Type, ex.Title, ex.Detail, ex.Errors };
            return BadRequest(errorResponse);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }
}
