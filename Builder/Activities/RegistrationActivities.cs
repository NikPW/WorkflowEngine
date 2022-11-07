using System.Reflection;
using ActivitiesApi;
using Core.Activities;
using Core.Workflows;
using DilshodWorkflowEngine.Service.Base;
using Microsoft.Extensions.DependencyInjection;
using WorkflowApi;

namespace Builder.Activities
{
    public static class RegistrationActivities
    {
        public static IServiceCollection RegisterActivities(this IServiceCollection collection)
        {
            if (IsActivitiesExistsInDatabase())
            {
                List<ActivityModel> activities = new List<ActivityModel>();
                Assembly mscorlib = typeof(BaseController).Assembly;
                foreach (var type in mscorlib.GetTypes())
                {
                    if (typeof(BaseController).IsAssignableFrom(type) || typeof(IBaseService).IsAssignableFrom(type))
                    {
                        var methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
                        for (int i = 0; i < methods.Length; ++i)
                        {
                            activities.Add(new ActivityModel()
                            {
                                Id = Guid.NewGuid().ToString(),
                                Name = methods[i].Name,
                                GroupName = type.Assembly.GetName().Name,
                                TypeName = type.Name,
                                ActionName = methods[i].Name
                            });
                        }
                    }
                }
            }

            return collection;
        }

        private static bool IsActivitiesExistsInDatabase()
        {
            return false;
        }
    }
}
