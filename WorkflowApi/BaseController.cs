using Extensions;
using Microsoft.AspNetCore.Mvc;

namespace WorkflowApi
{
    [ApiController]
    [Route("workflow/[controller]/[action]")]
    [SwaggerGroup("Workflow")]
    public class BaseController : ControllerBase
    {
        
    }
}
