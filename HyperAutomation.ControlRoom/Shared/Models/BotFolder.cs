using HyperAutomation.ControlRoom.Shared.Models;
using HyperAutomation.ControlRoom.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperAutomation.ControlRoom.Shared.Models
{
    public class BotFolder : EntityInfomation, ICustomClone<BotFolder>
    {
        public Guid BotFolderId { get; set; }
        public string Name { get; set; }

        // Relations
        public virtual ICollection<Bot> Bots { get; set; }

        public BotFolder CreateShallowCopy()
        {
            return (BotFolder)this.MemberwiseClone();
        }
    }
}
