using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveAnalyzerCommon;

namespace IsramarWaveAnalyzer
{
    public class IsramarWaveAnalyzerExtendedContainer : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IIsramarImageDownloader, IsramarImageDownloader>();
            Container.RegisterType<IIsramarImageAnalyzer, IsramarImageAnalyzer>();

            Container.RegisterType<IWaveAnalyzer, IsramarWaveAnalyzer>("IsramarWaveAnalyzer");           
        }
    }
}
