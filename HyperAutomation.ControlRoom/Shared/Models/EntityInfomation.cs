using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperAutomation.ControlRoom.Shared.Models
{
    public class EntityInfomation
    {
        public State State { get; set; } = State.DRAFT;
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime DeletedOn { get; set; }

        // Relations
        public Guid? CreatedByUserId { get; set; }
        public virtual UserProfile CreatedBy { get; set; }

        public Guid? ModifiedByUserId { get; set; }
        public virtual UserProfile ModifiedBy { get; set; }

        public Guid? DeletedByUserId { get; set; }
        public virtual UserProfile DeletedBy { get; set; }
    }

    public enum State
    {
        DRAFT,
        ARCHIVED,
        ATIVE
    }
}
