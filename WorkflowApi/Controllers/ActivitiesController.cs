using System.Reflection;
using ActivitiesApi;
using Core.Activities;
using Core.WorkflowBuilderModels;
using Core.Workflows;
using DilshodWorkflowEngine.Service;
using DilshodWorkflowEngine.Service.Base;
using Microsoft.AspNetCore.Mvc;

namespace WorkflowApi.Controllers
{
    public class ActivitiesController : BaseController
    {
        [HttpPost]
        public ActionResult BuildWorkflow()
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
