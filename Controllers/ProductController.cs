using CQRSDemo.Entities;
using CQRSDemo.Feature.Products.Command;
using CQRSDemo.Feature.Products.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(ISender _sender) : ControllerBase
{
    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<List<Product>>> GetAll()
    {
        var result = await _sender.Send(new GetAllProductsQuery());
        return Ok(result);
    }

    [HttpGet]
    [Route("GetById/{id}")]
    public async Task<ActionResult<Product>> GetAById(int id)
    {
        var result = await _sender.Send(new GetProductByIdQuery(id));
        return Ok(result);
    }

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> Create(CreateProductCommand value)
    {
        var result = await _sender.Send(value);
        return Ok(result);
    }
}
