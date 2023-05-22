using System;
using DWinProcessRPC.Settings;

namespace DWinProcessRPC;

public class Program
{
  public static void Main(string[] args)
  {
    Config config = new Config();
    Console.WriteLine(config.currentConfig?.ApplicationID);
  }

}
