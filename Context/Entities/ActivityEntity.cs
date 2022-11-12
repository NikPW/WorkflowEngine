namespace DatabaseContext.Entities
{
    public class ActivityEntity : BaseEntity
    {
        public int? Order { get; set; }
        public string GroupName { get; set; }
        
        public virtual WorkflowEntity? Workflow { get; set; }
        public string? WorkflowId { get; set; }
    }
}
