namespace DatabaseContext.Entities
{
    public class WorkflowEntity : BaseEntity
    {
        public string ServiceId { get; set; } = String.Empty;
        public virtual ICollection<ActivityEntity>? Activities { get; set; }
    }
}
