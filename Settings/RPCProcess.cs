namespace DWinProcessRPC.Settings;

internal class RPCProcess
{
  public string? ProcessName { get; set; }
  public string? LargeImageKey { get; set; }
  public string? SmallImageKey { get; set; }
  public string? LargeImageText { get; set; }
  public string? SmallImageText { get; set; }
  public string? Details { get; set; }
  public string? State { get; set; }
  public bool? ShowTimestamp { get; set; }
}
