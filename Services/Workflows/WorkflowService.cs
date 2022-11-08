using DatabaseContext;
using DatabaseContext.Entities;
using DilshodWorkflowEngine.Service.Base;
using Microsoft.EntityFrameworkCore;

namespace DilshodWorkflowEngine.Service.Workflows
{
    public class WorkflowService : BaseService
    {
        
        public WorkflowService(AppDbContext context) : base(context)
        { }
        
        public async Task<string> AddWorkflow(string name)
        {
            var id = Guid.NewGuid().ToString();

            using (var con = Context)
            {
                await con
                    .__workflows
                    .AddAsync(new WorkflowEntity()
                    {
                        Id = id,
                        Name = name
                    });

                await con.SaveChangesAsync();
            }
            
            return id;
        }

        public async Task<string> AddActivityToWorkflow(string workflowId)
        {
            List<ActivityEntity>? activities = null;
            
            if (!String.IsNullOrEmpty(workflowId))
            {
                activities = Context.__activities.Where(p => p.WorkflowId.Equals(workflowId)).ToList();
            }
            
            var id = Guid.NewGuid().ToString();
            
            if (activities != null)
            {
                activities.Add(new ActivityEntity());
            }

            return id;
        }
    }
}
