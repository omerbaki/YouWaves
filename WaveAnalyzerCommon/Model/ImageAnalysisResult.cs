using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveAnalyzerCommon.Model
{
    public abstract class WaveAnalysisResult
    {
        public abstract void Update(float markedPixelsPercentage, string imagePath);        
    }
}
