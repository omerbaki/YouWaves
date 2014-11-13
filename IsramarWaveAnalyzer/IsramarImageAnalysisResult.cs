using System.Collections.Generic;
using WaveAnalyzerCommon.Model;

namespace IsramarWaveAnalyzer
{
    public class IsramarImageAnalysisResult : ImageAnalysisResult
    {
        private Dictionary<string, float> mImageMarkedPixels;

        public IsramarImageAnalysisResult()
        {
            mImageMarkedPixels = new Dictionary<string, float>();
        }

        public override void Update(float markedPixelsPercentage, string imagePath)
        {
            mImageMarkedPixels[imagePath] = markedPixelsPercentage;
        }
    }
}
