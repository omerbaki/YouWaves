using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveAnalyzerCommon;
using WaveAnalyzerCommon.Model;

namespace IsramarWaveAnalyzer
{
    internal class IsramarWaveAnalyzer : WaveAnalyzerBase
    {
        public IsramarWaveAnalyzer(
            IIsramarImageDownloader imageDownloader,
            IIsramarImageAnalyzer imageAnalyzer)
            : base(imageDownloader, imageAnalyzer)
        {
        }

        protected override WaveAnalysisResult CreateImageAnalysisResult()
        {
            return new IsramarImageAnalysisResult();
        }

        public override bool ShouldRun()
        {
            bool alreadyRanToday = mLastRunTime.Date == DateTime.Today;
            return (DateTime.Now.Hour == 8) && !alreadyRanToday;
        }
    }
}
