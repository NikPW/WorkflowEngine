using Core.WorkflowBuilderModels;

namespace DilshodWorkflowEngine.Service.Interfaces
{
    public interface IWorkflowBuilder
    {
        public delegate string InputMethods(string activityId, string content);
        
        public BuildResultModel BuildWorkflow(Func<InputMethods> method);
    }
}
