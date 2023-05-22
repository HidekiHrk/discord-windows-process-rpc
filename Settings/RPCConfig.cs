namespace DWinProcessRPC.Settings;

internal class RPCConfig
{
  public string? ApplicationID { get; set; }
  public bool? InvertLargeAndSmallImages { get; set; }
  public Process[]? Processes { get; set; }
}
