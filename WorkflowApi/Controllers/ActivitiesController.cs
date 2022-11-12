using System.Reflection;
using ActivitiesApi;
using Core.Activities;
using Core.WorkflowBuilderModels;
using Core.Workflows;
using DatabaseContext;
using DatabaseContext.Entities;
using DilshodWorkflowEngine.Service;
using DilshodWorkflowEngine.Service.Activities;
using DilshodWorkflowEngine.Service.Base;
using Microsoft.AspNetCore.Mvc;

namespace WorkflowApi.Controllers
{
    public class ActivitiesController : BaseController
    {
        private readonly ActivitiesService _service;

        public ActivitiesController(ActivitiesService service)
        {
            _service = service;
        }
        
        [HttpPost]
        public async Task<IEnumerable<ActivityEntity>> GetRegisteredActivities([FromServices] AppDbContext context)
        {
            List<ActivityEntity> activities = context.__activities.Where(p => p.Id != null).ToList();

            return activities;
        }
    }
}
