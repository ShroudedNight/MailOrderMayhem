using BepInEx.Logging;

namespace com.shroudednight.MailOrderMayhem;

internal static class Extensions
{
    public static void INFO(this ManualLogSource logSource, string data) => logSource.Log(LogLevel.Info, data);
    public static void WARN(this ManualLogSource logSource, string data) => logSource.Log(LogLevel.Warning, data);
    public static void ERROR(this ManualLogSource logSource, string data) => logSource.Log(LogLevel.Error, data);
    public static void FATAL(this ManualLogSource logSource, string data) => logSource.Log(LogLevel.Fatal, data);
}