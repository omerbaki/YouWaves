using System;
using System.Collections.Generic;
using System.IO;
using LevYamWaveAnalyzer;

namespace ForecastAnalysisReport
{
    public interface IForecastAnalysisReportCreator
    {
        void CreateReport();
        DateTime LastReportCreatedAt { get; }
    }

    class ForecastAnalysisReportCreator : IForecastAnalysisReportCreator
    {
        private readonly IEnumerable<IWaveAnalyzer> mWaveAnalyzers;
        private DateTime mLastReportCreatedAt;

        public ForecastAnalysisReportCreator(IEnumerable<IWaveAnalyzer> aWaveAnalyzers)
        {
            mWaveAnalyzers = aWaveAnalyzers;
        }

        public void CreateReport()
        {
            //            string reportFileName = GetReportFileName();
            //
            //            var analyzersReportsModels = await GetWaveAnalysisReportModel();
            //            mJsonSerializer.Export(reportFileName, analyzersReportsModels);
            //
            //            mLastReportCreatedAt = DateTime.UtcNow;
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

        //        private async Task<WaveAnalysisReportModel> GetWaveAnalysisReportModel()
        //        {
        //            var waveAnalysisReportModel = new WaveAnalysisReportModel { CreatedAt = DateTime.Now };
        //
        //            foreach (var waveAnalyzer in mWaveAnalyzers)
        //            {
        //                try
        //                {
        //                    waveAnalysisReportModel.AddWaveAnalyzersReport(
        //                        waveAnalyzer.GetType().Name,
        //                        await waveAnalyzer.Analyze());
        //                }
        //                catch (Exception ex)
        //                {
        //                    //mLogger.Error(ex);
        //                }
        //            }
        //
        //            return waveAnalysisReportModel;
        //        }
    }
}
