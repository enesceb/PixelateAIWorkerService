using OpenAI.GPT3.Extensions;
using PixelateAIWorkerService;
using PixelateAIWorkerService.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddOpenAIService(settings => settings.ApiKey = "YOUR_API_KEY");
        services.AddHostedService<ImageService>();
    })
    .Build();

host.Run();
