using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveAnalyzerCommon.Model;

namespace LevYamWaveAnalyzer
{
    public class WindAlertImageAnalysisResult : ImageAnalysisResult
    {
        public float MarkedPixelsPercentage { get; set; }

        public override void Update(float markedPixelsPercentage, string imagePath)
        {
            if (MarkedPixelsPercentage < markedPixelsPercentage)
            {
                MarkedPixelsPercentage = markedPixelsPercentage;
            }
        }

        public override string GetAnalysisSummary()
        {
            // TODO: Translate MarkedPixelsPercentage to wave hight maybe
            return MarkedPixelsPercentage.ToString();
        }
    }
}
