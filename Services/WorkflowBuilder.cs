using System.Data;
using Core.WorkflowBuilderModels;
using DilshodWorkflowEngine.Service.Base;
using DilshodWorkflowEngine.Service.Interfaces;

namespace DilshodWorkflowEngine.Service
{
    public class WorkflowBuilder : IBaseService, IWorkflowBuilder
    {
        public WorkflowBuilder() : base()
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
