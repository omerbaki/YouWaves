using ForecastAnalysisNotificationCreator;
using ForecastNotificationSender;
using Framework;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastAnalysisNotificationRunner
{
    class Bootstrap
    {
        public static IUnityContainer CreateContainer()
        {
            IUnityContainer container = new UnityContainer();

            container.AddNewExtension<FrameworkExtendedContainer>();
            container.AddNewExtension<ForecastAnlysisNotificationCreatorExtendedContainer>();
            container.AddNewExtension<ForecastNotificationSenderExtendedContainer>();

            container.RegisterType<IForecastAnalysisNotificationRunner, ForecastAnalysisNotificationRunner>();

            return container;
        }
    }
}
