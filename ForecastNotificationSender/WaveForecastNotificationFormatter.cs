using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForecastNotificaitonEntities;
using Framework;

namespace ForecastNotificationSender
{
    public interface IWaveForecastNotificationFormatter
    {
        Task<EmailModel> GetEmailFormat();
    }

    class WaveForecastNotificationFormatter : IWaveForecastNotificationFormatter
    {
        private IJsonSerializer mJsonSerializer;

        public WaveForecastNotificationFormatter(IJsonSerializer jsonSerializer)
        {
            mJsonSerializer = jsonSerializer;
        }

        public async Task<EmailModel> GetEmailFormat()
        {
            var notificationsDirectory = Path.Combine("Notifications", DateTime.Now.ToString("yyyyMMdd"));
            string[] waveForecastNotifications = Directory.GetFiles(notificationsDirectory, typeof(WaveForecastNotification).Name + "*");
            var waveForecastNotification =
               (await mJsonSerializer.Import(waveForecastNotifications[0], typeof(WaveForecastNotification)))
               as WaveForecastNotification;

            var emailModel = new EmailModel();
            if(waveForecastNotification.IsramarStartDate == default(DateTime))
            {
                emailModel.Subject = "No waves in the coming 3 days";
            }
            else if (waveForecastNotification.IsramarEndDate == default(DateTime))
            {
                emailModel.Subject = string.Format("Waves coming on {0}", waveForecastNotification.IsramarStartDate.DayOfWeek);
                emailModel.Body =
                    string.Format(
                    "Waves coming on {0} at {1} lasting past {2}",
                    waveForecastNotification.IsramarStartDate.DayOfWeek,
                    waveForecastNotification.IsramarStartDate.ToString("h tt"),
                    waveForecastNotification.IsramarEndDate.DayOfWeek);
            }
            else
            {
                emailModel.Subject = string.Format("Waves coming on {0}", waveForecastNotification.IsramarStartDate.DayOfWeek);
                emailModel.Body =
                    string.Format(
                    "Waves coming on {0} at {1} lasting till {2} at {3}",
                    waveForecastNotification.IsramarStartDate.DayOfWeek,
                    waveForecastNotification.IsramarStartDate.ToString("h tt"),
                    waveForecastNotification.IsramarEndDate.DayOfWeek,
                    waveForecastNotification.IsramarEndDate.ToString("h tt"));
            }

            return emailModel;
        }
    }
}
