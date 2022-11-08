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
            /*
            List<ActivityEntity> activities = new List<ActivityEntity>();
            Assembly mscorlib = typeof(BaseController).Assembly;
            foreach (var type in mscorlib.GetTypes())
            {
                if (typeof(BaseController).IsAssignableFrom(type) || typeof(BaseService).IsAssignableFrom(type))
                {
                    var methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
                    for (int i = 0; i < methods.Length; ++i)
                    {
                        activities.Add(new ActivityEntity()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = methods[i].Name
                        });
                    }
                }
            }
            */
            /*
            context.__activities.AddRange(activities);
            context.SaveChanges();
            */

            List<ActivityEntity> activities = context.__activities.Where(p => p.Id != null).ToList();

            return activities;
        }
    }
}
