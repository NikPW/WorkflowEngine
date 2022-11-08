using Core.Workflows;
using DilshodWorkflowEngine.Service.Workflows;
using Microsoft.AspNetCore.Mvc;

namespace WorkflowApi.Controllers
{
    public class WorkflowBuilderController : BaseController
    {
        private readonly WorkflowService _service;

        public WorkflowBuilderController(WorkflowService service)
        {
            _service = service;
        }
        
        [HttpPost]
        public async Task<ActionResult<string>> BuildWorkflow([FromBody] string name)
        {
            return Ok(await _service.AddWorkflow(name));
        }

        
        
        [HttpPost]
        public ActionResult<List<Workflow>>  GetActivities()
        {
            return BadRequest("Not implemented");
        }
    }
}
