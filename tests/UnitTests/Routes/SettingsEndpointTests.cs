using Api.Routes.Web;
using Data.Access;

namespace UnitTests.Routes;

public class SettingsEndpointTests : UnitTestFor<SettingsEndpoint>
{
    protected override SettingsEndpoint CreateService()
    {
        return new SettingsEndpoint(Mock.Of<DataContext>(), Mock.Of<AutoMapper.IMapper>());
    }

    [Test]
    public async Task Handler_ReturnsSettingsResponse()
    {
        // Arrange

        // Act
        var response = await SUT.Handler(string.Empty);

        // Assert
        That(response, Is.InstanceOf<SettingsResponse>());
    }
}
