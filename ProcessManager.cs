using DWinProcessRPC.Settings;
using System.Diagnostics;


namespace DWinProcessRPC;

internal class ProcessManager
{
  RPCProcess[] rpcProcesses;

  public ProcessManager(RPCProcess[] rpcProcesses)
  {
    this.rpcProcesses = rpcProcesses;
  }

  public RPCProcess? findRPCProcess()
  {
    foreach (RPCProcess rpcProcess in this.rpcProcesses)
    {
      Process[] processes = Process.GetProcessesByName(rpcProcess.ProcessName);
      if (processes.Length > 0)
        return rpcProcess;
    }
    return null;
  }

}
