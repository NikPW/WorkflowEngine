using DatabaseContext;
using DatabaseContext.Entities;
using DilshodWorkflowEngine.Service.Base;
using Dto;
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

        public async Task AddActivityToWorkflow(AddActivityToWorkflowsDto dto)
        {
            var activity = await Context.__activities.FirstOrDefaultAsync(p => p.Id.Equals(dto.ActivityId));
            
            activity.WorkflowId = dto.WorkflowId;

            await Context.SaveChangesAsync();
        }
    }
}
