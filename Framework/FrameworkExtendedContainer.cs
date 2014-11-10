using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class FrameworkExtendedContainer : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IJsonSerializer, JsonSerializer>();
        }
    }
}
