using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels.ImageResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelateAIWorkerService.Services
{
    public class ImageService : BackgroundService
    {
        IOpenAIService _openAIService;

        public ImageService(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                Console.Write("::");
               ImageCreateResponse result = await _openAIService.Image.CreateImage(new ImageCreateRequest()
                {
                    Prompt = Console.ReadLine(),
                    N = 2,
                    Size = StaticValues.ImageStatics.Size.Size512,
                    ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                    User = "ImageUser"
                });
                Console.WriteLine(string.Join("\n", result.Results.Select(w => w.Url)));
            }
        }
    }
}
