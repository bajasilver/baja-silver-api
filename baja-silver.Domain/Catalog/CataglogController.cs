using Microsoft.AspNetCore.Mvc;
using Baja.Silver.Domain.Catalog;
//using System.Web.Mvc;

namespace Baja.Silver.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        protected override void ExecuteCore()
        {
            throw new NotImplementedException();
        }
    }

    [HttpGet]
    public IActionResult GetItems()
    {
        return Ok("hello world.");
    }
}