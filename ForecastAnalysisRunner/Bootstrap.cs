using LevYamImageAnalyzer;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastAnalysisRunner
{
    class Bootstrap
    {
        public static IUnityContainer CreateContainer()
        {
            IUnityContainer container = new UnityContainer();

            container.AddNewExtension<WindAlertImageAnalyzerExtendedContainer>();

            container.RegisterType<IForecastAnalysisRunner, ForecastAnalysisRunner>();

            return container;
        }
    }
}
