using Rage;

namespace OpenAllDoors
{
    internal static class Logger
    {
        private const string LogPrefix = "OpenAllDoors";
        
        internal static void DebugLog(string LogLine)
        {
            if (Globals.GeneralConfig.DebugLogging)
            {
                string log = $"[DEBUG]: {LogLine}";

                Game.LogTrivial(log);
            }
        }
    }
}