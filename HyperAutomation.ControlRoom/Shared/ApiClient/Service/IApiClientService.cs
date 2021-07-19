using HyperAutomation.ControlRoom.Shared.ApiClient.Provider;
using System.Threading.Tasks;

namespace HyperAutomation.ControlRoom.Shared.ApiClient.Service
{
    public interface IApiClientService
    {
        Task<IApiClientProvider> CreateInstanceAsync();
    }
}
