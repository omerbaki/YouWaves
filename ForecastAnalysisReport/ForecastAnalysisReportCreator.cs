using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Framework;
using LevYamWaveAnalyzer;
using WaveAnalyzerCommon;

namespace ForecastAnalysisReport
{
    public interface IForecastAnalysisReportCreator
    {
        Task CreateReport();
    }

    class ForecastAnalysisReportCreator : IForecastAnalysisReportCreator
    {
        private readonly IJsonSerializer mJsonSerializer;
        private readonly IEnumerable<IWaveAnalyzer> mWaveAnalyzers;

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
            await mJsonSerializer.Export(reportFileName, analyzersReportsModels);
        }

        private string GetReportFileName()
        {
            string reportFileName = DateTime.Now.ToString("yyyyMMdd_HHmm") + ".json";
            string directory = DateTime.Now.ToString("yyyyMMdd");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

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
