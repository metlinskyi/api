namespace UnitTests.Services;

using Api.Services;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Api;

public class GreeterServiceTests
{
    private GreeterService _greeterService;
    private Mock<ILogger<GreeterService>> _loggerMock;

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<GreeterService>>();
        _greeterService = new GreeterService(_loggerMock.Object);
    }

    [Test]
    public async Task SayHello_ReturnsExpectedMessage()
    {
        // Arrange
        var request = new HelloRequest { Name = "TestUser" };
        var context = new Mock<ServerCallContext>().Object;

        // Act
        var response = await _greeterService.SayHello(request, context);

        // Assert
        That(response.Message, Is.EqualTo("Hello TestUser"));
    }
}
