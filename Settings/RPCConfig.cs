namespace DWinProcessRPC.Settings;

internal class RPCConfig
{
  public int? UpdateIntervalInSeconds { get; set; }
  public string? ApplicationID { get; set; }
  public bool? SwapLargeAndSmallImages { get; set; }
  public RPCProcess[]? Processes { get; set; }
}
