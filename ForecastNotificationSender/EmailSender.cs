using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForecastNotificaitonEntities;

namespace ForecastNotificationSender
{
    public class EmailSender
    {
        private readonly IWaveForecastNotificationFormatter mWaveForecastNotificationFormatter;
        public EmailSender(IWaveForecastNotificationFormatter waveForecastNotificationFormatter)
        {
            mWaveForecastNotificationFormatter = waveForecastNotificationFormatter;
        }

        public void Send()
        {
            var emailFormat = mWaveForecastNotificationFormatter.GetEmailFormat();
        }
    }
}
