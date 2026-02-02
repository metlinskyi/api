namespace Api.Services.Images;
public record ImageOfTheDayRequest(int Month, int Day) : IRequest<ImageOfTheDayResponse>;