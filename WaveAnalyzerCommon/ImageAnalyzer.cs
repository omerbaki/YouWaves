using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveAnalyzerCommon.Model;

namespace WaveAnalyzerCommon
{
    public interface IImageAnalyzer
    {
        float AnalyzeImage(string imagePath);
    }

    public abstract class ImageAnalyzer : IImageAnalyzer
    {
        public float AnalyzeImage(string imagePath)
        {            
            var bitmap = new Bitmap(imagePath);
            var relevantArea = GetRelevantArea();

            var totalPixelsCount = GetTotalPixelSize(relevantArea);
            var markedPixelsCount = GetMarkedPixelCount(bitmap, relevantArea);

            return (float)markedPixelsCount / totalPixelsCount;
        }

        protected abstract Rectangle GetRelevantArea();

        protected abstract bool ShouldMarkPixel(Color color);        

        private int GetTotalPixelSize(Rectangle relevantArea)
        {
            return relevantArea.Width * relevantArea.Height;
        }

        private int GetMarkedPixelCount(Bitmap bitmap, Rectangle relevantArea)
        {
            int markedPixelCount = 0;
            for (int x = relevantArea.X; x < relevantArea.Right; x++)
            {
                for (int y = relevantArea.Y; y < relevantArea.Bottom; y++)
                {
                    // Get the color of a pixel within myBitmap.
                    Color pixelColor = bitmap.GetPixel(x, y);
                    if (ShouldMarkPixel(pixelColor))
                    {
                        markedPixelCount++;
                    }
                }
            }

            return markedPixelCount;
        }       
    }
}
