namespace ControlCenter.Shared.Factory.Service;

public class DefaultFactoryService : IFactoryService
{
    private readonly IServiceProvider _serviceProvider;

    public DefaultFactoryService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public T InstanceOf<T>()
    {
        return (T)_serviceProvider.GetService(typeof(T));
    }
}