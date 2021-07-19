using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperAutomation.ControlRoom.Shared.Models
{
    public class Team
    {
        public Guid TeamId { get; set; }

        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        // Relations
        public virtual ICollection<UserProfile> Users { get; set; }
    }
}
