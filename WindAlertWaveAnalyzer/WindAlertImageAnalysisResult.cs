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
        public float WhitePixelMax { get; set; }

        public override void Update(float markedPixelsPercentage, string imagePath)
        {
            if (WhitePixelMax < markedPixelsPercentage)
            {
                WhitePixelMax = markedPixelsPercentage;
            }
        }
    }
}
