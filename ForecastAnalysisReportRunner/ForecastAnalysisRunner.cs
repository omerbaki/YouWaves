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
        private IForecastAnalysisReportCreator mForecastAnalysisReportCreator;

        public ForecastAnalysisRunner(IForecastAnalysisReportCreator aForecastAnalysisReportCreator)
        {
            mForecastAnalysisReportCreator = aForecastAnalysisReportCreator;
        }

        public void Start()
        {
            try
            {
                Task.FromResult(mForecastAnalysisReportCreator.CreateReport());
            }
            catch(Exception ex)
            {

            }
        }
    }
}
