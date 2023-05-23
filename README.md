# Discord Windows Process Rich Presence

This app runs in background and listens to your configured processes aiming to showing up a beautiful rich presence on your discord.

Your config file is located at `<windowsPartition>:\Users\<yourUserName>\.dwinProcess.json` and will be created upon the first time you run the app.

## Config Example:

```json
{
  "UpdateIntervalInSeconds": 10,
  "ApplicationID": "688622210151219264",
  "SwapLargeAndSmallImages": false,
  "Processes": [
    {
      "ProcessName": "discord",
      "LargeImageKey": "image url or application image key",
      "SmallImageKey": "image url or application image key",
      "LargeImageText": "DISCORD",
      "SmallImageText": "discord",
      "Details": "DISCORD",
      "State": "discord",
      "ShowTimestamp": true
    }
  ]
}
```
