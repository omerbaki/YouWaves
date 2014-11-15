using ForecastAnalysisResultEntities;
using ForecastNotificaitonEntities;
using Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastAnalysisNotificationCreator
{
    public interface IWaveForecastNotificationCreator
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
            string[] isramarAnalysisResults = Directory.GetFiles(reportsDirectory, typeof(IsramarWaveAnalysisResult).Name + "*");
            if (isramarAnalysisResults.Length == 0) return;

            var waveForecastNotification = new WaveForecastNotification();

            var isramarWaveAnalysisResult = 
                (await mJsonSerializer.Import(isramarAnalysisResults[0], typeof(IsramarWaveAnalysisResult))) 
                as IsramarWaveAnalysisResult;            
            waveForecastNotification.IsramarStartDate = isramarWaveAnalysisResult.StartDate;
            waveForecastNotification.IsramarEndDate = isramarWaveAnalysisResult.EndDate;

            string notificationsDirectory = CreateNotificationsDirectory();
            string reportFileName =
                Path.Combine(notificationsDirectory, typeof(WaveForecastNotification).Name + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".json");

            await mJsonSerializer.Export(reportFileName, waveForecastNotification);
        }

        private string CreateNotificationsDirectory()
        {
            string directory = Path.Combine("Notifications", DateTime.Now.ToString("yyyyMMdd"));

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return directory;
        }
    }
}
