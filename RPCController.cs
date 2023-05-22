using System;
using DiscordRPC;

namespace DWinProcessRPC;

internal class RPCController
{
  public DiscordRpcClient client;
  public RPCController()
  {
    this.client = new DiscordRpcClient("688622210151219264");
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

    this.client.SetPresence(new RichPresence()
    {
      Details = "Opa",
      State = "Eae",
      Assets = new Assets()
      {
        LargeImageKey = "https://i.pinimg.com/originals/24/e9/ef/24e9ef0199309b4826787385e99b212d.jpg",
        SmallImageKey = "logo",
        LargeImageText = "TESTE LOGO GRANDE",
        SmallImageText = "teste logo pequena",
      }
    });
  }
}
