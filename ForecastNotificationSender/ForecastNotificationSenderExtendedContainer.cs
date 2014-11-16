using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastNotificationSender
{
    public class ForecastNotificationSenderExtendedContainer : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IEmailSender, EmailSender>();
            Container.RegisterType<IWaveForecastNotificationFormatter, WaveForecastNotificationFormatter>();
        }
    }    
}
