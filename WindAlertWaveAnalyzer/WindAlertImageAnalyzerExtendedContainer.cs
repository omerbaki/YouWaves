using LevYamWaveAnalyzer.Ben;
using LevYamWaveAnalyzer.Lev;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevYamWaveAnalyzer
{
    public class WindAlertImageAnalyzerExtendedContainer : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IImageDownloader, ImageDownloader>();
            Container.RegisterType<IImageAnalyzer, ImageAnalyzer>();

            Container.RegisterType<IWindAlertLevImageAnalyzer, WindAlertLevImageAnalyzer>();
            Container.RegisterType<IWindAlertLevImageDownloader, WindAlertLevImageDownloader>();

            Container.RegisterType<IWindAlertBenImageAnalyzer, WindAlertBenImageAnalyzer>();
            Container.RegisterType<IWindAlertBenImageDownloader, WindAlertBenImageDownloader>();

            Container.RegisterType<IWaveAnalyzer, WindAlertLevWaveAnalyzer>("LevWaveAnalyzer");
            Container.RegisterType<IWaveAnalyzer, WindAlertBenWaveAnalyzer>("BenWaveAnalyzer");
            Container.RegisterType<IEnumerable<IWaveAnalyzer>, IWaveAnalyzer[]>();
        }
    }
}
