using ForecastAnalysisResultEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveAnalyzerCommon;
using WaveAnalyzerCommon.Model;

namespace LevYamWaveAnalyzer
{
    internal abstract class WindAlertWaveAnalyzerBase : WaveAnalyzerBase
    {
        private const int HOUR_TO_START = 6;
        private const int HOUR_TO_FINISH = 16;

        public WindAlertWaveAnalyzerBase(IImageDownloader imageDownloader, IImageAnalyzer imageAnalyzer) : 
            base(imageDownloader, imageAnalyzer)
        { 
        }        

        public override bool ShouldRun()
        {
            return ((DateTime.Now.Hour >= HOUR_TO_START) &&
                    (DateTime.Now.Hour < HOUR_TO_FINISH) &&
                    (DateTime.Now - mLastRunTime).TotalMinutes > 20);
        }
    }
}
