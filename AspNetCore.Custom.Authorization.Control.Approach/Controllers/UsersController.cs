using AspNetCore.Custom.Authorization.Control.Approach.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Custom.Authorization.Control.Approach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TimeControlRequirement(30)]
    public class UsersController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok(true);
        }
    }
}
