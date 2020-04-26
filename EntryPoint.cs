/*

Developed By: HazyTube
Name: Open All Doors
Released on: GitHub

*/


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rage;

[assembly:
    Rage.Attributes.Plugin("Open All Doors",
        Description = "Open every vehicle door by standing next to it and pressing a key.", Author = "HazyTube")]

namespace OpenAllDoors
{
    public static class EntryPoint
    {
        public static void Main()
        {
            Globals.Application.PluginName = "OpenAllDoors";

            Game.LogTrivial(
                $"{Globals.Application.PluginName} {Assembly.GetExecutingAssembly().GetName().Version.ToString()} has been  initialized.");

            //This sets the currentversion
            Globals.Application.CurrentVersion = $"{Assembly.GetExecutingAssembly().GetName().Version}";

            //This sets the config path to /plugins/lspdfr for the ini file
            Globals.Application.ConfigPath = "Plugins";

            Globals.Application.ConfigFileName = "OpenAllDoors.ini";

            Game.LogTrivial(
                $"--------------------------------------{Globals.Application.PluginName} startup log--------------------------------------");

            //Checks for an update
            int versionStatus = Updater.CheckUpdate();

            if (versionStatus == -1)
            {
                Notifier.StartUpNotificationOutdated();
                Game.LogTrivial(
                    $"Plugin is out of date. (Current Version: {Globals.Application.CurrentVersion}) - (Latest Version: {Globals.Application.LatestVersion})");
            }
            else if (versionStatus == -2)
            {
                Game.LogTrivial("There was an issue checking plugin versions, the plugin may be out of date!");
            }
            else if (versionStatus == 1)
            {
                Notifier.StartUpNotification();
                Game.LogTrivial($"Plugin version v{Globals.Application.CurrentVersion} loaded succesfully");
            }

            if (File.Exists($"{Globals.Application.ConfigPath}{Globals.Application.ConfigFileName}"))
            {
                //Loads the config file (.ini file)
                Settings.LoadSettings();
            }
            else
            {
                Game.LogTrivial(
                    $"[ERROR] Config file {Globals.Application.ConfigFileName} does not exist, please check if the file is located in {Globals.Application.ConfigPath} before reporting this as a bug");
                Game.LogTrivial("[WARNING] The plugin will use the default keybindings now");
            }

            StartPlugin();
        }

        private static void StartPlugin()
        {
            GameFiber.StartNew(delegate
            {
                Logger.DebugLog("New gamefiber started");
                Core.RunPlugin();
            });
        }

        internal static class Core
        {
            public static void RunPlugin()
            {
                while (true)
                {
                    GameFiber.Yield();

                    Vehicle closestVehicle = (Vehicle) World.GetClosestEntity(Game.LocalPlayer.Character.Position, 4f,
                        GetEntitiesFlags.ConsiderAllVehicles);

                   /*var frontLeftDoor = closestVehicle.Doors[0];
                    var frontRightDoor = closestVehicle.Doors[1];
                    var backLeftDoor = closestVehicle.Doors[2];
                    var backRightDoor = closestVehicle.Doors[3];
                    var hood = closestVehicle.Doors[4];
                    var trunk = closestVehicle.Doors[5];
                    var backDoor = closestVehicle.Doors[6];
                    var backDoor2 = closestVehicle.Doors[6];*/

                   if (closestVehicle && Game.LocalPlayer.Character.DistanceTo(closestVehicle) < 4)
                   {
                       Game.DisplayHelp("Press ~g~T~s~ to open the closest vehicle door");
                   }

                   if (Game.IsKeyDown(Keys.T))
                   {
                       Game.DisplaySubtitle("~y~TEST TEST TEST TEST");
                   }
                }
            }
        }
    }
}