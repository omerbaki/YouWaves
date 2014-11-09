using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastAnalysisReport
{
    public class WaveAnalysisReportModel
    {
        public WaveAnalysisReportModel()
        {
            this.WaveAnalyzersReports = new List<WaveAnalyzerReportModel>();
        }

        public List<WaveAnalyzerReportModel> WaveAnalyzersReports { get; set; }

        public void AddWaveAnalyzersReport(string waveAnalyzerName, float analysisValue)
        {
            this.WaveAnalyzersReports.Add(new WaveAnalyzerReportModel()
            {
                WaveAnalyzerName = waveAnalyzerName,
                AnalysisValue = analysisValue,
            });
        }

        public DateTime CreatedAt { get; set; }
    }

    public class WaveAnalyzerReportModel
    {
        public string WaveAnalyzerName { get; set; }
        public float AnalysisValue { get; set; }
    }
}
