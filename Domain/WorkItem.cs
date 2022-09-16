using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum WorkItemType
    {
        BUG,
        EPIC,
        FEATURE,
        ISSUE,
        TASK,
        TESTCASE,
        USERSTORY
    }

    public class WorkItem
    {
        public Guid Id { get; set; }
        public WorkItemType WorkItemType { get; set; }
        public WorkItemState? CurrentState { get; set; }
        public List<WorkItemState>? AvailableWorkItemTypes { get; set; }
    }

}
