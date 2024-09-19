using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controller
{
    [ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
    }
}
