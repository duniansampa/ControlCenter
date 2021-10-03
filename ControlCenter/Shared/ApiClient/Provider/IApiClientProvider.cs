using ControlCenter.Shared.ApiClient.Models;

namespace ControlCenter.Shared.ApiClient.Provider;

public interface IApiClientProvider
{
    IApiClientProvider UseAuthenticationBearer(string bearerToken = null);

    IApiClientProvider UseJsonContentType();

    IApiClientProvider UseBaseUrl(string baseUrl);

    Task<ApiClientResult<T>> GetAsync<T>(string apiRoute) where T : new();

    Task<ApiClientResult<T>> PostAsync<T>(string apiRoute, object body) where T : new();
}
