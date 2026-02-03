using System.Reflection;
using Api.Services.Images;
using Data.Access;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Routes;

public class EndpointMapperTests : UnitTestFor<EndpointMapper>
{

    public override void Setup()
    {
        base.Setup();
    }

    [Test]
    public async Task Handler_ReturnsSettingsResponse()
    {
        var actual = SUT.BuildPattern(typeof(ImageOfTheDayRequest));
        That(actual, Is.EqualTo("/api/images/imageoftheday/"));
    }

    protected override EndpointMapper CreateService()
    {
        var _ = new EndpointMapper
        {
           UrlPattern = "/api/{namespace}/{name}/"
        };
        _.AddPattern(type => type.Namespace?.Replace(".", "/"), "namespace", "Api/Services/(?<namespace>.*)");
        _.AddPattern(type => type.Name, "name", "(?<name>.*)Service");
        _.AddPattern(type => type.Name, "name", "(?<name>.*)Request");  

        return _;
    }
}
