using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class WorkItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public WorkItemType WorkItemType { get; set; }
        public Guid WorkItemTypeId { get; set; }
        public WorkItemState WorkItemState { get; set; }
        public Guid? WorkItemStateId { get; set; }

    }
}
