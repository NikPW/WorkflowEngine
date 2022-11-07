using Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ActivitiesApi
{
    [ApiController]
    [Route("workflow/[controller]/[action]")]
    [SwaggerGroup("Workflow")]
    public class BaseController : ControllerBase
    {
        
    }
}
