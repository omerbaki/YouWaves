using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveAnalyzerCommon.Model;

namespace WaveAnalyzerCommon
{
    public interface IWaveAnalyzer
    {
        Task<string> Analyze();
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

        public async Task<string> Analyze()
        {
            string imageFolder = await mImageDownloader.DownloadImages();
            ImageAnalysisResult result = mImageAnalyzer.AnalyzeImages(imageFolder);
            return result.GetAnalysisSummary();
        }
    }
}
