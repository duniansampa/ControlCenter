using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperAutomation.ControlRoom.Shared.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O nome do usuário ou e-mail não pode ser vazio")]
        [MaxLength(60)]
        public string Login { get; set; }

        [Required(ErrorMessage = "O password não pode ser vazio")]
        [MinLength(8, ErrorMessage = "A senha deve conter no mínimo 8 caracteres")]
        public string Password { get; set; }
    }
}
