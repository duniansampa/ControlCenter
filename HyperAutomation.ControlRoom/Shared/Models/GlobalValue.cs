using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperAutomation.ControlRoom.Shared.Models
{
    public class GlobalValue
    {
        public Guid GlobalValueId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
