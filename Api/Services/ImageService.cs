using Grpc.Core;

namespace Api.Services;

public class ImageService : Image.ImageBase
{
    private readonly ILogger<ImageService> _logger;
    public ImageService(ILogger<ImageService> logger)
    {
        _logger = logger;
    }

    public override Task<ImageResponse> Image(ImageRequest request, IServerStreamWriter<ImageResponse> responseStream, ServerCallContext context)
    {
        // For demonstration, returning static data. In a real application, fetch data from a database or external service.
        return Task.FromResult(new ImageResponse
        {

        });
    }

    public override Task<ImageOfTheResponse> ImageOfTheDay(ImageOfTheDayRequest request, ServerCallContext context)
    {
        return Task.FromResult(new ImageOfTheResponse   
        {
            Url = "https://example.com/image-of-the-day.jpg",
            Title = "Image of the Day",
            Description = "A beautiful image representing the day." 
        });
    }
}
