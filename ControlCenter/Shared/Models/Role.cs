using System.ComponentModel.DataAnnotations;

namespace ControlCenter.Shared.Models;

public class Role
{
    public Guid RoleId { get; set; }

    [Required(ErrorMessage = "Nome da role não pode ser vazio")]
    [MaxLength(60)]
    public string Name { get; set; }
}
