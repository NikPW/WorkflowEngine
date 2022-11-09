using System.Reflection;
using Core.Activities;
using DatabaseContext;
using DatabaseContext.Entities;
using DilshodWorkflowEngine.Service;
using DilshodWorkflowEngine.Service.Activities;
using DilshodWorkflowEngine.Service.Base;
using DilshodWorkflowEngine.Service.Databases;
using DilshodWorkflowEngine.Service.Requests;
using DilshodWorkflowEngine.Service.Workflows;
using Extensions.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorkflowApi;

namespace Builder
{
    public static class DilshodBuilder
    {
        public static IServiceCollection AddWorkflowEngine(this IServiceCollection collection)
        {
            collection.AddTransient<DeleteData>();
            collection.AddTransient<SaveData>();
            collection.AddTransient<UpdateData>();
            collection.AddTransient<SendGrpcRequest>();
            collection.AddTransient<SendHttpRequest>();
            collection.AddTransient<WorkflowBuilder>();
            collection.AddTransient<WorkflowService>();
            collection.AddTransient<ActivitiesService>();
            
            collection.AddControllers();
            
            collection.AddMvc().AddApplicationPart(Assembly.Load(new AssemblyName("WorkflowApi")));
            
            return collection;
        }

        /// <summary>
        /// Receives existing DbConnection for workflows. 
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="connectionString"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static IServiceCollection AddDatabaseConnection(this IServiceCollection collection, 
            string connectionString,
            EfProviders provider)
        {
            switch (provider)
            {
                case EfProviders.SqlLite: 
                    collection.AddDbContext<AppDbContext>(o => o.UseSqlite(connectionString));
                    break;
                case EfProviders.MsSql: 
                    collection.AddDbContext<AppDbContext>(o => o.UseSqlServer(connectionString));
                    break;
            }
            
            return collection;
        }

        public static IServiceCollection AddBasicActivities(this IServiceCollection collection)
        {
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
            
            return collection;
        }
    }
}
