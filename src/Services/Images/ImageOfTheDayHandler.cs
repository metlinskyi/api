namespace Api.Services.Images;

public class ImageOfTheDayHandler : IRequestHandler<ImageOfTheDayRequest, ImageOfTheDayResponse>
{
    public Task<ImageOfTheDayResponse> Handle(ImageOfTheDayRequest request, CancellationToken cancellationToken)
    {
        // Implementation goes here
        return Task.FromResult(new ImageOfTheDayResponse("https://example.com/image.jpg", "An example image description."));
    }
}