using System.Data;
using Core.WorkflowBuilderModels;
using DatabaseContext;
using DilshodWorkflowEngine.Service.Base;
using DilshodWorkflowEngine.Service.Interfaces;

namespace DilshodWorkflowEngine.Service
{
    public class WorkflowBuilder : BaseService, IWorkflowBuilder
    {
        public WorkflowBuilder(AppDbContext context) : base(context)
        {
            
        }
        
        public BuildResultModel BuildWorkflow(Func<IWorkflowBuilder.InputMethods> method)
        {
            BuildResultModel result = new BuildResultModel();
            result.WorkflowId = Guid.NewGuid().ToString();

            
            
            return null;
        }
    }
}
