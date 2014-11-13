using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveAnalyzerCommon.Model;

namespace ForecastAnalysisReport
{
    public class WaveAnalysisReportModel
    {
        public WaveAnalysisReportModel()
        {
            this.WaveAnalyzersReports = new List<WaveAnalysisResult>();
        }

        public List<WaveAnalysisResult> WaveAnalyzersReports { get; set; }

        public DateTime CreatedAt { get; set; }
    }   
}
