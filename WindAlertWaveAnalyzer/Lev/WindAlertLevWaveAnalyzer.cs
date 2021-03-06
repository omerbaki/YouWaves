﻿using ForecastAnalysisResultEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveAnalyzerCommon;

namespace LevYamWaveAnalyzer.Lev
{
    internal class WindAlertLevWaveAnalyzer : WindAlertWaveAnalyzerBase
    {
        public WindAlertLevWaveAnalyzer(
            IWindAlertLevImageDownloader imageDownloader,
            IWindAlertLevImageAnalyzer imageAnalyzer)
            : base(imageDownloader, imageAnalyzer)
        {
        }

        protected override WaveAnalysisResult CreateImageAnalysisResult()
        {
            return new WindAlertLevWaveAnalysisResult();
        }
    }
}
