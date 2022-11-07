using ActivitiesApi;
using Core.Workflows;
using Microsoft.AspNetCore.Mvc;

namespace WorkflowApi.Controllers
{
    public class WorkflowBuilderController : BaseController
    {
        [HttpPost]
        public ActionResult BuildWorkflow([FromBody] WorkflowForm form)
        {
            return BadRequest("Not implemented");
        }

        [HttpPost]
        public ActionResult<List<Workflow>>  GetActivities()
        {
            return BadRequest("Not implemented");
        }
    }
}
