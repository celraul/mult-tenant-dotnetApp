using Cupcake.Api.Core.Models;
using Cupcake.Application.Models.Store;
using Cupcake.Application.UseCases.ProductUseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cupcake.Api.Controllers.store;

[ApiController]
[Route("api/v1/store/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IMediator _mediator;

    public ProductController(ILogger<ProductController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    /// <summary>
    /// Get list of products.
    /// </summary>
    /// <returns>Product Id.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<List<ProdutModel>>), StatusCodes.Status200OK)]
    public async Task<ActionResult> Get(string? name, [FromQuery] PaginationParameters pagination)
    {
        List<ProdutModel> result =
            await _mediator.Send(new GetProductsQuery(name ?? string.Empty, pagination.Skip, pagination.Take));

        ApiResponse<List<ProdutModel>> apiResponse = new(result);

        return Ok(apiResponse);
    }
}
