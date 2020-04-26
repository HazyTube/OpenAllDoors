using System.Windows.Forms;

namespace OpenAllDoors
{
    public class Globals
    {
        internal static class GeneralConfig
        {
            public static bool DebugLogging { get; set; }
            public static bool OpenDoorHelp { get; set; }
        }
        
        internal static class Controls
        {
            public static Keys OpenDoorKey { get; set; }
            public static Keys OpenDoorModifier { get; set; }
        }

        internal static class Application
        {
            public static string ConfigPath { get; set; }
            public static string ConfigFileName { get; set; }
            public static string CurrentVersion { get; set; }
            public static string LatestVersion { get; set; }
            public static string PluginName { get; set; }
        }
    }
}
