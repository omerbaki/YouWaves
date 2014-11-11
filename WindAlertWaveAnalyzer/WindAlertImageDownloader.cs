using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveAnalyzerCommon;
using WaveAnalyzerCommon.Model;

namespace LevYamWaveAnalyzer
{
    internal abstract class WindAlertImageDownloader : ImageDownloader
    {
        private const string WIND_ALERT_IMAGE_URL = "http://www.windalert.co.il/cameras/{0}?1";

        protected override DownloadImageModel[] GetImageModels()
        {
            var imageModels = new List<DownloadImageModel>();
            for (int i = 0; i <= 9; i++)
            {
                imageModels.Add(new DownloadImageModel()
                {
                    ImageUrl = string.Format(WIND_ALERT_IMAGE_URL, string.Format(GetImageName(), i)),
                    ImageName = string.Format(GetImageName(), i)
                });
            }

            return imageModels.ToArray();
        }

        protected abstract string GetImageName();
    }
}
