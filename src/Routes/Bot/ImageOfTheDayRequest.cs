namespace Api.Routes.Bot;
public record ImageOfTheDayRequest(int Month, int Day) : IRequest<ImageOfTheDayResponse>;