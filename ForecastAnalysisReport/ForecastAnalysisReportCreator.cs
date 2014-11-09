using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Framework;
using LevYamWaveAnalyzer;

namespace ForecastAnalysisReport
{
    public interface IForecastAnalysisReportCreator
    {
        Task CreateReport();
        DateTime LastReportCreatedAt { get; }
    }

    class ForecastAnalysisReportCreator : IForecastAnalysisReportCreator
    {
        private readonly IJsonSerializer mJsonSerializer;
        private readonly IEnumerable<IWaveAnalyzer> mWaveAnalyzers;
        private DateTime mLastReportCreatedAt;

        public ForecastAnalysisReportCreator(
            IEnumerable<IWaveAnalyzer> aWaveAnalyzers,
            IJsonSerializer aJsonSerializer)
        {
            mWaveAnalyzers = aWaveAnalyzers;
            mJsonSerializer = aJsonSerializer;
        }

        public async Task CreateReport()
        {
            var reportFileName = GetReportFileName();

            var analyzersReportsModels = await GetWaveAnalysisReportModel();
            mJsonSerializer.Export(reportFileName, analyzersReportsModels);

            mLastReportCreatedAt = DateTime.UtcNow;
        }

        public DateTime LastReportCreatedAt
        {
            get { return mLastReportCreatedAt; }
        }

        private string GetReportFileName()
        {
            string reportFileName = Path.Combine(DateTime.Now.ToString("yyyyMMdd_HHmm"), ".json");
            reportFileName = Path.Combine(DateTime.Now.ToString("yyyyMMdd"), reportFileName);
            return reportFileName;
        }

        private async Task<WaveAnalysisReportModel> GetWaveAnalysisReportModel()
        {
            var waveAnalysisReportModel = new WaveAnalysisReportModel { CreatedAt = DateTime.Now };

            foreach (var waveAnalyzer in mWaveAnalyzers)
            {
                try
                {
                    waveAnalysisReportModel.AddWaveAnalyzersReport(
                        waveAnalyzer.GetType().Name,
                        await waveAnalyzer.Analyze());
                }
                catch (Exception ex)
                {
                    //mLogger.Error(ex);
                }
            }

            return waveAnalysisReportModel;
        }
    }
}
