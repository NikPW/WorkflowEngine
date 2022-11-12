using System.Reflection;
using DatabaseContext;
using DatabaseContext.Entities;
using DilshodWorkflowEngine.Service.Base;
using Microsoft.Extensions.DependencyInjection;
using WorkflowApi;

namespace Builder.Activities
{
    public class ActivityBuildHelper
    {
        public static List<ActivityEntity> GetActivitiesInAssembly(Assembly assembly)
        {
            List<ActivityEntity> activities = new List<ActivityEntity>();
            
            foreach (var type in assembly.GetTypes())
            {
                if (typeof(BaseController).IsAssignableFrom(type) || typeof(BaseService).IsAssignableFrom(type))
                {
                    var methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
                    for (int i = 0; i < methods.Length; ++i)
                    {
                        activities.Add(new ActivityEntity()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = methods[i].Name,
                            GroupName = type.Name
                        });
                    }
                }
            }

            return activities;
        }

        public static void SaveActivitiesToDatabase(AppDbContext context, List<ActivityEntity> activities)
        {
            var registeredActivities = context.__activities.Where(p => p.Id != null);
            List<string> regActivitiesNames = new List<string>();

            foreach (var regActivity in registeredActivities)
            {
                regActivitiesNames.Add(regActivity.Name);
            }

            context.__activities.AddRange(activities.Where(p => p.Id != null).DistinctBy(p => p.Name));

            context.SaveChanges();
        }
    }
}
