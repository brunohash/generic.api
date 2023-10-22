using Application.Commands;
using Application.Dtos;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenericApi.Controllers;

[Route("v1/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    [Authorize(Roles = "generic")]
    [HttpPost]
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
