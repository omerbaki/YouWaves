using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveAnalyzerCommon;

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
    }
}
