using Api.Routes.Web;
using Data.Access;

namespace UnitTests.Routes;

public class SettingsEndpointTests : UnitTestFor<SettingsEndpoint>
{
    protected override SettingsEndpoint CreateService()
    {
        return new SettingsEndpoint(null, null);
    }

    [Test]
    public async Task Handler_ReturnsSettingsResponse()
    {
        // Arrange

        // Act
        //var response = await SUT.Handle(null, CancellationToken.None);

        // Assert
        //That(response, Is.InstanceOf<SettingsResponse>());
    }
}
