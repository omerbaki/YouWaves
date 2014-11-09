using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevYamWaveAnalyzer.Model
{
    internal class ImageAnalysisResult
    {
        public float WhitePixelAvg { get; set; }
        public float WhitePixelMax { get; set; }

        public void Update(float whitePixelsPercentage, int counter)
        {
            if (WhitePixelMax < whitePixelsPercentage)
            {
                WhitePixelMax = whitePixelsPercentage;
            }

            WhitePixelAvg = (whitePixelsPercentage + WhitePixelAvg) / counter;
        }
    }
}
