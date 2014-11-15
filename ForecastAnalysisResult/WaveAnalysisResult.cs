using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastAnalysisResultEntities
{
    public abstract class WaveAnalysisResult
    {
        private DateTime mCreatedAt;
        public WaveAnalysisResult()
        {
            mCreatedAt = DateTime.Now;
        }

        public DateTime CreatedAt { get { return mCreatedAt; } }

        public abstract void Update(float markedPixelsPercentage, string imagePath);
    }
}
