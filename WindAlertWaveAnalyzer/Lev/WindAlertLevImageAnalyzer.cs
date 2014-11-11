﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveAnalyzerCommon;

namespace LevYamWaveAnalyzer.Lev
{
    internal interface IWindAlertLevImageAnalyzer : IImageAnalyzer
    {
    }

    internal class WindAlertLevImageAnalyzer : ImageAnalyzer, IWindAlertLevImageAnalyzer
    {
        protected override Rectangle GetRelevantArea()
        {
            return new Rectangle(0, 300, 630, 170);
        }
    }
}
