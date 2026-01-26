using Api.Routes.Web;

namespace UnitTests.Routes;

public class SettingsEndpointTests : UnitTestFor<SettingsEndpoint>
{
    protected override SettingsEndpoint CreateService()
    {
        return new SettingsEndpoint(null);
    }

    [Test]
    public async Task Handler_ReturnsSettingsResponse()
    {
        // Arrange

        // Act
        var response = await SUT.Handler();

        // Assert
        That(response, Is.InstanceOf<SettingsResponse>());
    }
}
