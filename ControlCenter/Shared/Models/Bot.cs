namespace ControlCenter.Shared.Models;

public class Bot : EntityInfomation
{
    public Guid BotId { get; set; }
    public string Name { get; set; }

    public string Status { get; set; }
    public string Description { get; set; }

    public double Size { get; set; }

    public int Type { get; set; }

    // Relations
    public BotFolder Folder { get; set; }
}