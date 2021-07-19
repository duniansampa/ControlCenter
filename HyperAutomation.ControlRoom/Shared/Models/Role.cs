using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperAutomation.ControlRoom.Shared.Models
{
    public class Role
    {
        public Guid RoleId { get; set; }

        [Required(ErrorMessage = "Nome da role não pode ser vazio")]
        [MaxLength(60)]
        public string Name { get; set; }
    }
}
