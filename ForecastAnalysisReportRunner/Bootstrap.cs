using ForecastAnalysisReport;
using Framework;
using LevYamWaveAnalyzer;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveAnalyzerCommon;

namespace ForecastAnalysisRunner
{
    class Bootstrap
    {
        public static IUnityContainer CreateContainer()
        {
            IUnityContainer container = new UnityContainer();

            container.AddNewExtension<FrameworkExtendedContainer>();
            container.AddNewExtension<WaveAnalyzerCommonExtendedContainer>();
            container.AddNewExtension<WindAlertWaveAnalyzerExtendedContainer>();
            container.AddNewExtension<ForecastAnalysisReportExtendedContainer>();

            container.RegisterType<IForecastAnalysisRunner, ForecastAnalysisRunner>();

            return container;
        }
    }
}
