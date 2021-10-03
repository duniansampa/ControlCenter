namespace ControlCenter.Shared.Utils;

public class RouteItem
{
    public string Name { get; set; }
    public string Path { get; set; }
    public string Icon { get; set; }
    public string Mini { get; set; }
    public bool State { get; set; }
    public IEnumerable<RouteItem> SubItems { get; set; }
}
