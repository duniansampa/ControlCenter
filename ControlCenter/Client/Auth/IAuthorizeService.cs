namespace ControlCenter.Client.Auth;

public interface IAuthorizeService
{
    Task Login(string token);
    Task Logout();
}
