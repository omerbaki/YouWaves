using ForecastAnalysisResultEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveAnalyzerCommon;
using WaveAnalyzerCommon.Model;

namespace LevYamWaveAnalyzer.Ben
{
    internal class WindAlertBenWaveAnalyzer : WindAlertWaveAnalyzerBase
    {
        public WindAlertBenWaveAnalyzer(
            IWindAlertBenImageDownloader imageDownloader,
            IWindAlertBenImageAnalyzer imageAnalyzer)
            : base(imageDownloader, imageAnalyzer)
        {
        }

        protected override WaveAnalysisResult CreateImageAnalysisResult()
        {
            return new WindAlertBenWaveAnalysisResult();
        }
    }
}
