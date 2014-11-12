using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveAnalyzerCommon;
using WaveAnalyzerCommon.Model;

namespace IsramarWaveAnalyzer
{
    internal interface IIsramarImageDownloader : IImageDownloader
    {
    }

    internal class IsramarImageDownloader : ImageDownloader, IIsramarImageDownloader
    {
        private const string ISRAMAR_IMAGE_NAME = "isramar.{0}.gif";
        private const string ISRAMAR_IMAGE_URL = "http://isramar.ocean.org.il/isramar2009/wave_model/wave_maps/wam/{0}/coarse/{1}.windir.gif";
        
        protected override DownloadImageModel[] GetImageModels()
        {
            // Today format for URL - 1411110000
            string todayFormat = DateTime.Today.ToString("yyMMddHHmm");

            DateTime currentDate = DateTime.Today;
            var imageModels = new List<DownloadImageModel>();
            for (int i = 0; i < 24; i++)
            {
                // Image date format - 14111112
                string imageDateFormat = currentDate.ToString("yyMMddHH");

                imageModels.Add(new DownloadImageModel()
                {                    
                    ImageUrl = string.Format(ISRAMAR_IMAGE_URL, todayFormat, imageDateFormat),
                    ImageName = string.Format(ISRAMAR_IMAGE_NAME, imageDateFormat)
                });

                currentDate = currentDate.AddHours(3);
            }

            return imageModels.ToArray();
        }

        protected override string GetDownloaderName()
        {
            return "Isramar";
        }
    }
}
