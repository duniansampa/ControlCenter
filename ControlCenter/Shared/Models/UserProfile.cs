using ControlCenter.Shared.Utils;
using System.ComponentModel.DataAnnotations;

namespace ControlCenter.Shared.Models;

public class UserProfile : ICustomClone<BotFolder>
{
    [Key]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "O nome do usuário não pode ser vazio")]
    [MaxLength(60)]
    public string UserName { get; set; }

    [Required(ErrorMessage = "O campo email não pode ser vazio")]
    [EmailAddress(ErrorMessage = "Formato do email inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O password não pode ser vazio")]
    [MinLength(8, ErrorMessage = "A senha deve conter no mínimo 8 caracteres")]
    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? Foto { get; set; }

    public bool IsSuperUser { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastLogin { get; set; }

    public DateTime? ModifiedOn { get; set; }

    // Relations
    public Guid? ModifiedByUserId { get; set; }
    public virtual UserProfile? ModifiedBy { get; set; }

    public virtual ICollection<Team> Teams { get; set; }

    public BotFolder CreateShallowCopy()
    {
        return (BotFolder)MemberwiseClone();
    }
}