using System.Threading.Tasks;

namespace HyperAutomation.ControlRoom.Client.Auth
{
    public interface IAuthorizeService
    {
        Task Login(string token);
        Task Logout();
    }
}
