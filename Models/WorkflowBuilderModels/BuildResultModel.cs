namespace Core.WorkflowBuilderModels
{
    public class BuildResultModel
    {
        public string WorkflowId { get; set; } = String.Empty;
        public Dictionary<int, string> ActivityIds { get; set; } = new Dictionary<int, string>();
    }
}
