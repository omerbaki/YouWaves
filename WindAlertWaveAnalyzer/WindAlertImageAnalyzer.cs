using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveAnalyzerCommon;
using WaveAnalyzerCommon.Model;

namespace LevYamWaveAnalyzer
{
    internal abstract class WindAlertImageAnalyzer : ImageAnalyzer
    {
        const double WHITE_PIXEL_COLOR_THRESHOLD = 120;

        protected override bool ShouldMarkPixel(Color color)
        {
            return color.R > WHITE_PIXEL_COLOR_THRESHOLD && color.G > WHITE_PIXEL_COLOR_THRESHOLD && color.B > WHITE_PIXEL_COLOR_THRESHOLD;
        }       
    }
}
