using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Kipuh.API.Kipuh.Inventory.Interface.Rest;

[ApiController]
[Route("/api/v0/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Controller for Products - CRUD 💎")]
public class ProductController : ControllerBase
{
    public ProductController()
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetProduct()
    {
        return Ok("Works!");
    }
}