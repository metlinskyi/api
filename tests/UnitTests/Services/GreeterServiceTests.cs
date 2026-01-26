namespace UnitTests.Services;

using Api.Services;
using Grpc.Core;

public class GreeterServiceTests : UnitTestFor<GreeterService>
{
    protected override GreeterService CreateService()
    {
        return new GreeterService(LoggerMock.Object);
    }

    [Test]
    public async Task SayHello_ReturnsExpectedMessage()
    {
        // Arrange
        var request = new HelloRequest { Name = "TestUser" };
        var context = new Mock<ServerCallContext>().Object;

        // Act
        var response = await SUT.SayHello(request, context);

        // Assert
        That(response.Message, Is.EqualTo("Hello TestUser"));
    }
}
