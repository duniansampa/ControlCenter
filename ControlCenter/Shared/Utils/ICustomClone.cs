namespace ControlCenter.Shared.Utils;

public interface ICustomClone<T>
{
    T CreateShallowCopy();
}