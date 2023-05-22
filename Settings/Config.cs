using System;
using System.IO;
using System.Text.Json;

namespace DWinProcessRPC.Settings;

internal class Config
{
  public RPCConfig? currentConfig;
  public string userFolder { get; }
  public const string CONFIG_FILE_NAME = ".dwinProcess.json";
  public string configFilePath
  {
    get
    {
      return Path.Join(this.userFolder, CONFIG_FILE_NAME);
    }
  }
  public Config()
  {
    this.userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    this.createFile();
    this.readFile();
  }

  public void createFile()
  {
    string currentPath = this.configFilePath;
    if (File.Exists(currentPath)) return;
    RPCConfig defaultRPCConfig = new RPCConfig()
    {
      ApplicationID = "688622210151219264",
      InvertLargeAndSmallImages = false,
      Processes = new Process[] { }
    };
    string serializedDefaultConfig = JsonSerializer.Serialize(defaultRPCConfig,
      new JsonSerializerOptions()
      {
        WriteIndented = true
      }
    );
    File.WriteAllLines(currentPath, new string[] { serializedDefaultConfig });
  }

  public void readFile()
  {
    string currentPath = this.configFilePath;
    if (!File.Exists(currentPath))
      throw new FileNotFoundException(String.Format(
        "The intended file \"{0}\" was not found in your user folder.", currentPath));
    string configJson = File.ReadAllText(currentPath);
    RPCConfig? currentRpcConfig = JsonSerializer.Deserialize<RPCConfig>(configJson);
    this.currentConfig = currentRpcConfig;
  }
}
