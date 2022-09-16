namespace Domain
{
    public class WorkItemType
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public List<WorkItemState>? AvailableWorkItemStates { get; set; }
    }

}
