using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForecastNotificaitonEntities;

namespace ForecastNotificationSender
{
    public interface IWaveForecastNotificationFormatter
    {
        string GetEmailFormat();
    }

    class WaveForecastNotificationFormatter : IWaveForecastNotificationFormatter
    {
        public string GetEmailFormat()
        {
            var notificationsDirectory = Path.Combine("Notifications", DateTime.Now.ToString("yyyyMMdd"));
            string[] waveForecastNotifications = Directory.GetFiles(notificationsDirectory, typeof(WaveForecastNotification).Name + "*");

            return string.Empty;
        }
    }
}
