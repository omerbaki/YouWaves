using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Framework;
using LevYamWaveAnalyzer;
using WaveAnalyzerCommon;
using System.Reactive.Linq;

namespace ForecastAnalysisReport
{
    public interface IForecastAnalysisReportCreator
    {
        void Start();
        void RunOnce();
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

        public void Start()
        {
            var timer = Observable.Interval(TimeSpan.FromMinutes(10));
            timer.Subscribe(x => RunOnce());
        }

        public void RunOnce()
        {
            Task.FromResult(CreateReports());
        }

        private async Task CreateReports()
        {
            string directory = CreateReportDirectory();

            foreach (var waveAnalyzer in mWaveAnalyzers)
            {
                try
                {
                    if (!waveAnalyzer.ShouldRun()) continue;

                    var waveAnalysisResult = await waveAnalyzer.Analyze();

                    string reportFileName = 
                        Path.Combine(directory, waveAnalyzer.GetType().Name + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".json");

                    await mJsonSerializer.Export(reportFileName, waveAnalysisResult);
                }
                catch (Exception ex)
                {
                    //mLogger.Error(ex);
                }
            }
            
        }

        private string CreateReportDirectory()
        {
            string directory = Path.Combine("Reports", DateTime.Now.ToString("yyyyMMdd"));

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return directory;
        }


        
    }
}
