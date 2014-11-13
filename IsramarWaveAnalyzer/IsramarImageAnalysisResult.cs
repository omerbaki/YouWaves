using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
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

        public override string GetAnalysisSummary()
        {
            string startDate = null;
            string endDate = null;
            foreach (var imageMarkPixel in mImageMarkedPixels)
            {
                if (imageMarkPixel.Value > 0.9 && string.IsNullOrEmpty(startDate))
                {
                    startDate = imageMarkPixel.Key;
                }
                else if (imageMarkPixel.Value < 0.9 && !string.IsNullOrEmpty(startDate))
                {
                    endDate = imageMarkPixel.Key;
                    break;
                }
            }

            if (string.IsNullOrEmpty(startDate))
            {
                return "No waves in the next 3 days";
            }
            else if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                return string.Format("Waves starting at {0} and ending at {1}", startDate, endDate);
            }
            else if (!string.IsNullOrEmpty(startDate))
            {
                return string.Format("Waves starting at {0} and lasting after {1}", startDate, mImageMarkedPixels.Keys.Last());
            }

            return "Error analyzing report";
        }
    }
}
