using System;
using DiscordRPC;
using DWinProcessRPC.Settings;

namespace DWinProcessRPC;

internal class RPCController
{
  public DiscordRpcClient client;

  public bool swapLargeImages = false;
  public RPCController(string applicationID, bool swapLargeImages = false)
  {
    this.client = new DiscordRpcClient(applicationID);
    this.swapLargeImages = swapLargeImages;
  }

  public void Initialize()
  {
    this.client.OnReady += (sender, e) =>
    {
      Console.WriteLine("Ready!");
    };
    this.client.OnPresenceUpdate += (sender, e) =>
    {
      Console.WriteLine("New presence {0}", e.Presence);
    };

    this.client.Initialize();
  }

  public void SetPresence(RPCProcess rpcProcess)
  {
    this.client.SetPresence(new RichPresence()
    {
      Details = rpcProcess.Details,
      State = rpcProcess.State,
      Timestamps = (rpcProcess.ShowTimestamp ?? false) ? new Timestamps(DateTime.UtcNow) : null,
      Assets = new Assets()
      {
        LargeImageKey = this.swapLargeImages ? rpcProcess.SmallImageKey : rpcProcess.LargeImageKey,
        SmallImageKey = this.swapLargeImages ? rpcProcess.LargeImageKey : rpcProcess.SmallImageKey,
        LargeImageText = this.swapLargeImages ? rpcProcess.SmallImageText : rpcProcess.LargeImageText,
        SmallImageText = this.swapLargeImages ? rpcProcess.LargeImageText : rpcProcess.SmallImageText,
      }
    });
  }

  public void ClearPresence() => this.client.ClearPresence();

  public void AddEventListenerReady(DiscordRPC.Events.OnReadyEvent callback)
  {
    this.client.OnReady += callback;
  }

  public void RemoevEventListenerReady(DiscordRPC.Events.OnReadyEvent callback)
  {
    this.client.OnReady -= callback;
  }
}
