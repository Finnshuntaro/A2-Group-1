using System.IO;
using UnityEngine;

public static class InteractionLogger
{
    private static readonly string logFilePath = Application.dataPath + "/Logs/SamuelLogs/interaction_log.txt";

    static InteractionLogger()
    {
        string folder = Path.GetDirectoryName(logFilePath);
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
    }

    public static void Log(string message)
    {
        string timestamp = $"[{System.DateTime.Now}] ";
        File.AppendAllText(logFilePath, timestamp + message + "\n");
    }
}