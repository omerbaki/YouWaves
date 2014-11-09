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
        private const int HOUR_TO_START = 5;
        private const int HOUR_TO_FINISH = 19;
        private const int CREATE_REPORT_INTERVAL_MINUTES = 60;

        private readonly IForecastAnalysisReportCreator mForecastAnalysisReportCreator;

        public ForecastAnalysisReportScheduler(IForecastAnalysisReportCreator forecastAnalysisReportCreator)
        {
            mForecastAnalysisReportCreator = forecastAnalysisReportCreator;
        }

        public void Start()
        {
            var timer = Observable.Interval(TimeSpan.FromSeconds(5));
            timer.Subscribe(x => Task.FromResult(RunReportScheduler()));
        }

        private async Task RunReportScheduler()
        {
            try
            {
                if (!ShouldCreateReport()) return;

                mForecastAnalysisReportCreator.CreateReport();
            }
            catch (Exception ex)
            {
                //mLogger.Error(ex);
            }
        }

        private bool ShouldCreateReport()
        {
            return
                (DateTime.Now - mForecastAnalysisReportCreator.LastReportCreatedAt).TotalMinutes > CREATE_REPORT_INTERVAL_MINUTES &&
                IsDaylightTime();
        }

        private bool IsDaylightTime()
        {
            return ((DateTime.Now.Hour > HOUR_TO_START) &&
                    (DateTime.Now.Hour < HOUR_TO_FINISH));
        }
    }
}
