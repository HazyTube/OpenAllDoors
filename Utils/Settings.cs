using System.Windows.Forms;
using Rage;

namespace OpenAllDoors
{
    internal static class Settings
    {
        private static InitializationFile initialiseFile(string filepath)
        {
            InitializationFile ini = new InitializationFile(filepath);
            ini.Create();
            return ini;
        }

        public static void LoadSettings()
        {
            InitializationFile settings = initialiseFile($"{Globals.Application.ConfigPath}{Globals.Application.ConfigFileName}");

            //Makes a new key converter to convert a string to a key
            KeysConverter kc = new KeysConverter();

            string OpenDoorKey, OpenDoorModifier;
            
            //GENERAL
            //Reads the settings from the general section in the ini file
            Globals.GeneralConfig.DebugLogging = settings.ReadBoolean("General", "DebugLogging", false);
            Globals.GeneralConfig.OpenDoorHelp = settings.ReadBoolean("General", "OpenDoorHelp", true);
            
            //KEYBINDINGS
            //Reads the keybindings from the ini file
            OpenDoorKey = settings.ReadString("Keybindings", "OpenDoorKey", "T");
            OpenDoorModifier = settings.ReadString("Keybindings", "OpenDoorModifierKey", "None");
            
            //KEY CONVERTERS
            //Converts strings to keys
            Globals.Controls.OpenDoorKey = (Keys) kc.ConvertFromString(OpenDoorKey);
            Globals.Controls.OpenDoorModifier = (Keys) kc.ConvertFromString(OpenDoorModifier);

            Game.LogTrivial($"[KEYBINDINGS] OpenDoorKey is set to {Globals.Controls.OpenDoorKey}");
            Game.LogTrivial("-----------------------------------------------------------------------------------------------------");
        }
    }
}