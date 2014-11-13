using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using WaveAnalyzerCommon.Model;

namespace IsramarWaveAnalyzer
{
    public class IsramarImageAnalysisResult : WaveAnalysisResult
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public override void Update(float markedPixelsPercentage, string imagePath)
        {
            if (markedPixelsPercentage >= 0.9f && string.IsNullOrEmpty(StartDate))
            {
                StartDate = imagePath;
            }
            else if (markedPixelsPercentage < 0.9 && !string.IsNullOrEmpty(StartDate) && string.IsNullOrEmpty(EndDate))
            {
                EndDate = imagePath;                
            }
        }        
    }
}
