using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastAnalysisResult
{
    public class IsramarWaveAnalysisResult : WaveAnalysisResult
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
