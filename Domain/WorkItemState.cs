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
        ACTIVE,
        RESOLVED,
        CLOSED,
        REMOVED

    }
    public class WorkItemState
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public WorkItemBaseState WorkItemBaseState { get; set; }
        public bool Default { get; set; } = false;
    }
}
