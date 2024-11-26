using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;

namespace Ordering.API.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        
    }
}
