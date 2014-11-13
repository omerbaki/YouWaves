using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastAnalysisReport
{
    public class ForecastAnalysisReportExtendedContainer : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IForecastAnalysisReportCreator, ForecastAnalysisReportCreator>();            
        }
    }
}
