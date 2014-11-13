using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveAnalyzerCommon.Model;

namespace LevYamWaveAnalyzer
{
    public class WindAlertWaveAnalysisResult : WaveAnalysisResult
    {
        public float MarkedPixelsPercentage { get; set; }

        public override void Update(float markedPixelsPercentage, string imagePath)
        {
            if (MarkedPixelsPercentage < markedPixelsPercentage)
            {
                MarkedPixelsPercentage = markedPixelsPercentage;
            }
        }
    }
}
