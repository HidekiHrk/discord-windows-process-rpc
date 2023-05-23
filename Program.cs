using DWinProcessRPC.Settings;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;


namespace DWinProcessRPC;

public class Program
{
  Config config = new Config();
  RPCController? controller;
  public bool started = false;

  public Program()
  {
    this.config = new Config();
  }

  public void StartNotificationArea()
  {
    Thread thread = new Thread(this.SetupNotificationArea);
    thread.Start();
  }

  public void SetupNotificationArea()
  {
    Container notifyIconComponentContainer = new Container();
    Container contextMenuComponentContainer = new Container();
    NotifyIcon notifyIcon = new NotifyIcon(notifyIconComponentContainer);
    notifyIcon.Icon = new Icon("Assets/icon.ico");
    notifyIcon.Text = "Discord Windows Process RPC";

    ContextMenuStrip contextMenu = new ContextMenuStrip(contextMenuComponentContainer);

    Image exitImage = Image.FromFile("Assets/exit.ico");
    contextMenu.Items.Add("Exit", exitImage, (sender, ev) =>
    {
      this.started = false;
      Application.Exit();
    });

    notifyIcon.ContextMenuStrip = contextMenu;

    notifyIcon.Visible = true;
    Application.Run();
  }

  public void Start()
  {
    if (this.started) return;
    this.started = true;
    Thread thread = new Thread(this.RPCProcessLoop);
    thread.Start();
  }

  public void Stop()
  {
    this.started = false;
  }

  public void RPCProcessLoop()
  {
    if (this.config.currentConfig?.ApplicationID is null ||
      this.config.currentConfig?.Processes is null) return;

    ProcessManager processManager = new ProcessManager(
      this.config.currentConfig.Processes);

    this.controller = new RPCController(
      this.config.currentConfig.ApplicationID,
      this.config.currentConfig?.SwapLargeAndSmallImages ?? false);
    this.controller.Initialize();

    int interval = this.config.currentConfig?.UpdateIntervalInSeconds ?? 10;

    RPCProcess? currentRpcProcess = null;

    DiscordRPC.Events.OnReadyEvent readyEvent = (sender, ev) =>
    {
      currentRpcProcess = null;
    };
    this.controller.AddEventListenerReady(readyEvent);

    while (this.started)
    {
      if (this.controller.client.IsInitialized)
      {
        RPCProcess? rpcProcess = processManager.findRPCProcess();
        if (rpcProcess is null)
        {
          this.controller.ClearPresence();
          currentRpcProcess = null;
        }
        else if (currentRpcProcess != rpcProcess)
        {
          currentRpcProcess = rpcProcess;
          this.controller.SetPresence(rpcProcess);
        }
      }
      for (int i = 0; i < interval && this.started; i++)
        Thread.Sleep(1000);
    }

    this.controller.RemoevEventListenerReady(readyEvent);
  }

  public static void Main(string[] args)
  {
    Program program = new Program();
    program.StartNotificationArea();
    program.Start();
  }
}
