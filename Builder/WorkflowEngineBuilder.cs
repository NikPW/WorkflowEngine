using System.Reflection;
using Builder.Activities;
using DatabaseContext;
using DilshodWorkflowEngine.Service;
using DilshodWorkflowEngine.Service.Activities;
using DilshodWorkflowEngine.Service.Databases;
using DilshodWorkflowEngine.Service.Requests;
using DilshodWorkflowEngine.Service.Workflows;
using Extensions.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
            return collection.RegisterActivities();
        }
    }
}
