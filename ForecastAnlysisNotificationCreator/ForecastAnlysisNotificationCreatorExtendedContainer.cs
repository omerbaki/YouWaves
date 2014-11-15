using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastAnalysisNotificationCreator
{
    public class ForecastAnlysisNotificationCreatorExtendedContainer : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IWaveForecastNotificationCreator, WaveForecastNotificationCreator>();
        }
    }
}
