using ForecastAnalysisResult;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveAnalyzerCommon.Model;

namespace WaveAnalyzerCommon
{
    public interface IWaveAnalyzer
    {    
        Task<WaveAnalysisResult> Analyze();
        bool ShouldRun();
    }

    public abstract class WaveAnalyzerBase : IWaveAnalyzer
    {
        private readonly IImageDownloader mImageDownloader;
        private readonly IImageAnalyzer mImageAnalyzer;

        protected DateTime mLastRunTime;

        protected WaveAnalyzerBase(IImageDownloader imageDownloader, IImageAnalyzer imageAnalyzer)
        {
            mImageDownloader = imageDownloader;
            mImageAnalyzer = imageAnalyzer;
        }

        public async Task<WaveAnalysisResult> Analyze()
        {
            mLastRunTime = DateTime.Now;

            var result = CreateImageAnalysisResult();

            string imageFolder = await mImageDownloader.DownloadImages();

            var imagesPaths = Directory.GetFiles(imageFolder);
            foreach (var imagePath in imagesPaths)
            {
                if (new FileInfo(imagePath).Length == 0) continue;

                result.Update(mImageAnalyzer.AnalyzeImage(imagePath), imagePath);
            }

            return result;
        }

        protected abstract WaveAnalysisResult CreateImageAnalysisResult();

        public abstract bool ShouldRun();
    }
}
