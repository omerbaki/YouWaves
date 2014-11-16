using ForecastAnalysisNotificationCreator;
using ForecastNotificationSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastAnalysisNotificationRunner
{
    public interface IForecastAnalysisNotificationRunner
    {
        void Start();
    }

    class ForecastAnalysisNotificationRunner : IForecastAnalysisNotificationRunner
    {
        private readonly IWaveForecastNotificationCreator mWaveForecastNotificationCreator;
        private readonly IEmailSender mEmailSender;

        public ForecastAnalysisNotificationRunner(
            IWaveForecastNotificationCreator aWaveForecastNotificationCreator,
            IEmailSender emailSender)
        {
            mWaveForecastNotificationCreator = aWaveForecastNotificationCreator;
            mEmailSender = emailSender;
        }

        public void Start()
        {
            try
            {
                //mWaveForecastNotificationCreator.CreateNotification();
                mEmailSender.Send();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
