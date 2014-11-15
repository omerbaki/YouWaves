using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastAnalysisNotificationRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Program initiator = new Program();
            initiator.Init();
        }

        private void Init()
        {
            var container = Bootstrap.CreateContainer();

            var runner = container.Resolve<IForecastAnalysisNotificationRunner>();
            runner.Start();

            Console.ReadLine();
        }
    }
}
