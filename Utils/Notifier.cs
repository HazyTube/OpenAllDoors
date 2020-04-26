using Rage;
using System.Reflection;

namespace OpenAllDoors
{
    internal static class Notifier
    {
        private const string NotificationPrefix = "OpenAllDoors";

        internal static void Notify(string body)
        {
            string notice = string.Format("~p~[{0}]~s~: {1}", NotificationPrefix, body);
            Game.DisplayNotification(notice);
            Logger.DebugLog("Notification Sent.");
        }

        internal static void NotifySubtitle(string body)
        {
            string subtitle = string.Format("~p~[{0}]~s~: {1}", NotificationPrefix, body);
            Game.DisplaySubtitle(subtitle);
            Logger.DebugLog("Subtitle Sent.");
        }

        internal static void StartUpNotification()
        {
            Game.DisplayNotification("web_lossantospolicedept", "web_lossantospolicedept", NotificationPrefix, "~y~v" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " ~o~by HazyTube", "~b~Has been loaded.");
            Logger.DebugLog("Startup Notification Sent.");
        }

        internal static void StartUpNotificationOutdated()
        {
            Game.DisplayNotification("web_lossantospolicedept", "web_lossantospolicedept", NotificationPrefix, "~y~v" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " ~o~by HazyTube", "~r~Plugin is out of date! Please update the plugin.");
            Logger.DebugLog("Startup Notification (Outdated) Sent.");
        }
    }
}
