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
        public ForecastAnalysisRunner()
        {   
        }

        public void Start()
        {
        }
    }
}
