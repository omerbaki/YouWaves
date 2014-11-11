using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastAnalysisReport
{
    public interface IForecastAnalysisReportScheduler
    {
        void Start();
    }

    class ForecastAnalysisReportScheduler : IForecastAnalysisReportScheduler
    {
        private const int HOUR_TO_START = 6;
        private const int HOUR_TO_FINISH = 17;
        private const int CREATE_REPORT_INTERVAL_MINUTES = 20;

        private readonly IForecastAnalysisReportCreator mForecastAnalysisReportCreator;

        public ForecastAnalysisReportScheduler(IForecastAnalysisReportCreator forecastAnalysisReportCreator)
        {
            mForecastAnalysisReportCreator = forecastAnalysisReportCreator;
        }

        public void Start()
        {
            var timer = Observable.Interval(TimeSpan.FromSeconds(CREATE_REPORT_INTERVAL_MINUTES));
            timer.Subscribe(x => Task.FromResult(RunReportScheduler()));
        }

        private async Task RunReportScheduler()
        {
            try
            {
                if (!IsDaylightTime()) return;

                await mForecastAnalysisReportCreator.CreateReport();
            }
            catch (Exception ex)
            {
                //mLogger.Error(ex);
            }
        }

        private bool IsDaylightTime()
        {
            return ((DateTime.Now.Hour > HOUR_TO_START) &&
                    (DateTime.Now.Hour < HOUR_TO_FINISH));
        }
    }
}
