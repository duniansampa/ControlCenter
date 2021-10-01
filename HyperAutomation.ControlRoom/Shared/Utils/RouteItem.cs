using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperAutomation.ControlRoom.Shared.Utils
{
    public class RouteItem
    {
        public string Name { get; set; }
        public string Path { get; set; } = null;
        public string Icon { get; set; } = null;
        public string Mini { get; set; } = null;
        public bool State { get; set; } = false;
        public IEnumerable<RouteItem> SubItems { get; set; } = null;
    }
}
