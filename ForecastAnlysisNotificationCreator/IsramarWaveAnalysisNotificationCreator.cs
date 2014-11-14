using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastAnlysisNotificationCreator
{
    public class IIsramarWaveAnalysisNotificationCreator
    { }

    public class IsramarWaveAnalysisNotificationCreator : IIsramarWaveAnalysisNotificationCreator
    {
        public void CreateNotification()
        {
            string reportsDirectory = Path.Combine("Reports", DateTime.Now.ToString("yyyyMMdd"));
            //Directory.GetFiles(reportsDirectory, IsramarWaveAnalyzer);
        }
    }
}
