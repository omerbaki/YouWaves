using LevYamImageAnalyzer.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevYamImageAnalyzer
{
    internal interface IImageAnalyzer
    {
        ImageAnalysisResult AnalyzeImages(string aFolderName);
    }

    internal abstract class ImageAnalyzer : IImageAnalyzer
    {
        const double WHITE_PIXEL_COLOR_THRESHOLD = 120;

        public ImageAnalysisResult AnalyzeImages(string aFolderName)
        {
            var result = new ImageAnalysisResult();

            string[] imagesPaths = Directory.GetFiles(aFolderName);

            int counter = 0;
            foreach (string imagePath in imagesPaths)
            {
                if (new FileInfo(imagePath).Length == 0) continue;

                counter++;

                // Create a Bitmap object from an image file.
                var bitmap = new Bitmap(imagePath);
                var relevantArea = GetRelevantArea();

                var totalPixelsCount = GetTotalPixelSize(relevantArea);
                var whitePixelsCount = GetWhitePixelCount(bitmap, relevantArea);

                float whitePixelsPercentage = (float)whitePixelsCount / totalPixelsCount;

                result.Update(whitePixelsPercentage, counter);
            }

            return result;
        }

        protected abstract Rectangle GetRelevantArea();

        private int GetTotalPixelSize(Rectangle relevantArea)
        {
            return relevantArea.Width * relevantArea.Height;
        }

        private static int GetWhitePixelCount(Bitmap bitmap, Rectangle relevantArea)
        {
            int whitePixelCount = 0;
            for (int x = relevantArea.X; x < relevantArea.Right; x++)
            {
                for (int y = relevantArea.Y; y < relevantArea.Bottom; y++)
                {
                    // Get the color of a pixel within myBitmap.
                    Color pixelColor = bitmap.GetPixel(x, y);
                    if (IsWhitePixel(pixelColor))
                    {
                        whitePixelCount++;
                    }
                }
            }

            return whitePixelCount;
        }

        private static bool IsWhitePixel(Color color)
        {
            return color.R > WHITE_PIXEL_COLOR_THRESHOLD && color.G > WHITE_PIXEL_COLOR_THRESHOLD && color.B > WHITE_PIXEL_COLOR_THRESHOLD;
        }
    }
}

