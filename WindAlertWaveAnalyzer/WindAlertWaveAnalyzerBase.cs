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
        public WindAlertWaveAnalyzerBase(IImageDownloader imageDownloader, IImageAnalyzer imageAnalyzer) : 
            base(imageDownloader, imageAnalyzer)
        { 
        }

        protected override WaveAnalysisResult CreateImageAnalysisResult()
        {
            return new WindAlertWaveAnalysisResult();
        }
    }
}
