using ControlCenter.Shared.ApiClient.Provider;

namespace ControlCenter.Shared.ApiClient.Service;

public interface IApiClientService
{
    Task<IApiClientProvider> CreateInstanceAsync();
}

