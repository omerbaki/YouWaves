using ForecastAnalysisNotificationCreator;
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
        private IWaveForecastNotificationCreator mWaveForecastNotificationCreator;

        public ForecastAnalysisNotificationRunner(IWaveForecastNotificationCreator aWaveForecastNotificationCreator)
        {
            mWaveForecastNotificationCreator = aWaveForecastNotificationCreator;
        }

        public void Start()
        {
            try
            {
                mWaveForecastNotificationCreator.CreateNotification();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
