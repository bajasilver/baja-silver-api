using Microsoft.AspNetCore.Mvc;
using Baja.Silver.Domain.Catalog;

namespace Baja.Silver.Api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase {
        
    }
    [HttpGet]
    public IActionResult GetItems() {
        return Ok("hello world.");
    }
}