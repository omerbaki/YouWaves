using ForecastAnalysisResultEntities;
using ForecastNotificaitonEntities;
using Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastAnlysisNotificationCreator
{
    public class IWaveForecastNotificationCreator
    {
        Task CreateNotification();
    }

    public class WaveForecastNotificationCreator : IWaveForecastNotificationCreator
    {
        private IJsonSerializer mJsonSerializer;

        public WaveForecastNotificationCreator(IJsonSerializer jsonSerializer)
        {
            mJsonSerializer = jsonSerializer;
        }

        public async Task CreateNotification()
        {
            string reportsDirectory = Path.Combine("Reports", DateTime.Now.ToString("yyyyMMdd"));
            string[] isramarAnalysisResults = Directory.GetFiles(reportsDirectory, typeof(IsramarWaveAnalysisResult).Name);
            if (isramarAnalysisResults.Length == 0) return;

            var waveForecastNotification = new WaveForecastNotification();

            var isramarWaveAnalysisResult = (IsramarWaveAnalysisResult)(await mJsonSerializer.Import(isramarAnalysisResults[0]));
            waveForecastNotification.IsramarStartDate = isramarWaveAnalysisResult.StartDate;
            waveForecastNotification.IsramarEndDate = isramarWaveAnalysisResult.EndDate;

            //mJsonSerializer.Export(waveForecastNotification);
        }
    }
}
