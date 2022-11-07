using Core.Activities;

namespace Core.Workflows
{
    public class Workflow
    {
        public string Id { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public List<string> PrevWorkflowsId { get; set; } = new List<string>();
        public List<string> NextWorkflowsId { get; set; } = new List<string>();
        public List<ActivityModel> Activities { get; set; } = new List<ActivityModel>();
    }
}
