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
    }

    public abstract class WaveAnalyzerBase : IWaveAnalyzer
    {
        private readonly IImageDownloader mImageDownloader;
        private readonly IImageAnalyzer mImageAnalyzer;

        protected WaveAnalyzerBase(IImageDownloader imageDownloader, IImageAnalyzer imageAnalyzer)
        {
            mImageDownloader = imageDownloader;
            mImageAnalyzer = imageAnalyzer;
        }

        public async Task<WaveAnalysisResult> Analyze()
        {
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
    }
}
