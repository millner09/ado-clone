using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum WorkItemBaseState
    {
        PROPOSED,
        INPROGRESS,
        COMPLETED,
        REMOVED

    }
    public class WorkItemState
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public WorkItemBaseState WorkItemBaseState { get; set; }
        public WorkItemType? WorkItemType { get; set; }
        public Guid WorkItemTypeId { get; set; }
    }
}
