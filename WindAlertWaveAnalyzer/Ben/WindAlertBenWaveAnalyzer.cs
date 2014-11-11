using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveAnalyzerCommon;

namespace LevYamWaveAnalyzer.Ben
{
    internal class WindAlertBenWaveAnalyzer : WaveAnalyzerBase
    {
        public WindAlertBenWaveAnalyzer(
            IWindAlertBenImageDownloader imageDownloader,
            IWindAlertBenImageAnalyzer imageAnalyzer)
            : base(imageDownloader, imageAnalyzer)
        {
        }
    }
}
