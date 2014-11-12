using ForecastAnalysisReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastAnalysisRunner
{
    public interface IForecastAnalysisRunner
    {
        void Start();
    }

    class ForecastAnalysisRunner : IForecastAnalysisRunner
    {
        private IForecastAnalysisReportScheduler mForecastAnalysisReportScheduler;

        public ForecastAnalysisRunner(IForecastAnalysisReportScheduler aForecastAnalysisReportScheduler)
        {
            mForecastAnalysisReportScheduler = aForecastAnalysisReportScheduler;
        }

        public void Start()
        {
            try
            {
                mForecastAnalysisReportScheduler.RunOnce();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
