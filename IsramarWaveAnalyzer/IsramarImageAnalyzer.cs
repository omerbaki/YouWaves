using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveAnalyzerCommon;
using WaveAnalyzerCommon.Model;

namespace IsramarWaveAnalyzer
{
    internal interface IIsramarImageAnalyzer : IImageAnalyzer
    {
    }

    internal class IsramarImageAnalyzer : ImageAnalyzer, IIsramarImageAnalyzer
    {
        protected override Rectangle GetRelevantArea()
        {
            return new Rectangle(730, 315, 66, 45);
        }

        protected override bool ShouldMarkPixel(Color color)
        {
            if ((color.R == 0 && color.G == 1 && color.B == 0) ||
                (color.R == 255 && color.G == 255 && color.B == 254) ||
                (color.R == 202 && color.G == 204 && color.B == 201) ||
                (color.R == 204 && color.G == 255 && color.B == 255) ||
                (color.R == 168 && color.G == 235 && color.B == 235) ||
                (color.R == 134 && color.G == 216 && color.B == 217) ||
                (color.R == 106 && color.G == 194 && color.B == 209))
            {
                return false;
            }

            return true;  
        }     
    }
}
