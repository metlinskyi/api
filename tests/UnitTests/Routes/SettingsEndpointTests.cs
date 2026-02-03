
using Api.Services.Web;
using Data.Access;

namespace UnitTests.Routes;

public class SettingsEndpointTests : UnitTestFor<SettingsHandler>
{
    protected override SettingsHandler CreateService()
    {
        return new SettingsHandler(null, null);
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
