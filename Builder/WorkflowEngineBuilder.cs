using System.Data;
using System.Reflection;
using ActivitiesApi.Activities;
using DatabaseContext;
using DilshodWorkflowEngine.Service;
using DilshodWorkflowEngine.Service.Base;
using DilshodWorkflowEngine.Service.Databases;
using DilshodWorkflowEngine.Service.Requests;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.Extensions.DependencyInjection;

namespace Builder
{
    public static class DilshodBuilder
    {
        public static IServiceCollection AddWorkflowEngine(this IServiceCollection collection)
        {
            collection.AddTransient<GetActivity>();
            collection.AddTransient<DeleteData>();
            collection.AddTransient<SaveData>();
            collection.AddTransient<UpdateData>();
            collection.AddTransient<SendGrpcRequest>();
            collection.AddTransient<SendHttpRequest>();
            collection.AddTransient<WorkflowBuilder>();
            
            collection.AddControllers();
            
            collection.AddMvc().AddApplicationPart(Assembly.Load(new AssemblyName("WorkflowApi")));
            return collection;
        }
        
        /// <summary>
        /// Receives existing DbConnection for workflows. 
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static IServiceCollection AddDatabaseConnection(this IServiceCollection collection, 
            AppDbContext context)
        {
            IBaseService.Connection = context;

            return collection;
        }
        
        /// <summary>
        /// Receives connection string and uses it to instantiate DbConnection for workflows. 
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IServiceCollection AddDatabaseConnection(this IServiceCollection collection, 
            string connectionString)
        {
            var contextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connectionString)
                .Options;
            using var context = new AppDbContext(contextOptions);

            return collection;
        }

        public static IServiceCollection AddActivities(this IServiceCollection collection)
        {
            Assembly services = typeof(string).Assembly;
            foreach (Type type in services.GetTypes())
            {
                
            }

            return collection;
        }
    }
}
