using System.Reflection;
using Builder.Activities;
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
using Management;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorkflowApi;

namespace Builder
{
    public static class WorkflowEngineBuilder
    {
        public static IServiceCollection AddWorkflowEngine(this IServiceCollection collection)
        {
            collection.AddTransient<WorkflowBuilder>();
            collection.AddTransient<WorkflowService>();
            collection.AddTransient<ActivitiesService>();
            collection.AddHostedService<WorkflowManager>();
            
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
            Assembly servicesAssembly = typeof(BaseService).Assembly;

            activities.AddRange(ActivityBuildHelper.GetActivitiesInAssembly(servicesAssembly));

            using (ServiceProvider serviceProvider = collection.BuildServiceProvider())
            {
                var appDbContext = serviceProvider.GetRequiredService<AppDbContext>();
                ActivityBuildHelper.SaveActivitiesToDatabase(appDbContext, activities);
            }

            return collection;
        }

        public static IServiceCollection AddCustomActivities(this IServiceCollection collection)
        {
            List<ActivityEntity> activities = new List<ActivityEntity>();
            Assembly assembly = Assembly.GetCallingAssembly();

            activities.AddRange(ActivityBuildHelper.GetActivitiesInAssembly(assembly));

            using (ServiceProvider serviceProvider = collection.BuildServiceProvider())
            {
                var appDbContext = serviceProvider.GetRequiredService<AppDbContext>();
                ActivityBuildHelper.SaveActivitiesToDatabase(appDbContext, activities);
            }

            return collection;
        }

        public static IServiceCollection AddCustomActivities(this IServiceCollection collection,
            Assembly assembly)
        {
            List<ActivityEntity> activities = new List<ActivityEntity>();

            activities.AddRange(ActivityBuildHelper.GetActivitiesInAssembly(assembly));

            using (ServiceProvider serviceProvider = collection.BuildServiceProvider())
            {
                var appDbContext = serviceProvider.GetRequiredService<AppDbContext>();
                ActivityBuildHelper.SaveActivitiesToDatabase(appDbContext, activities);
            }

            return collection;
        }
    }
}
