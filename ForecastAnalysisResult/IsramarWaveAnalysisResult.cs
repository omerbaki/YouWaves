using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastAnalysisResultEntities
{
    public class IsramarWaveAnalysisResult : WaveAnalysisResult
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public override void Update(float markedPixelsPercentage, string imagePath)
        {
            if (markedPixelsPercentage >= 0.85f && StartDate == DateTime.MinValue)
            {
                string dateFromFileName = Path.GetFileNameWithoutExtension(imagePath).Replace("isramar.", "");
                StartDate = DateTime.ParseExact(dateFromFileName, "yyMMddHH", CultureInfo.InvariantCulture);
            }
            else if (markedPixelsPercentage < 0.5 && StartDate > DateTime.MinValue && EndDate == DateTime.MinValue)
            {
                string dateFromFileName = Path.GetFileNameWithoutExtension(imagePath).Replace("isramar.", "");
                EndDate = DateTime.ParseExact(dateFromFileName, "yyMMddHH", CultureInfo.InvariantCulture);          
            }
        }        
    }
}
