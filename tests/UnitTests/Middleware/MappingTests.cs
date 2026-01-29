using System.Reflection;
using Api.Routes.Web;
using Data.Access;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Routes;

public class MappingTests : UnitTestFor<SettingsEndpoint>
{
    protected override SettingsEndpoint CreateService()
    {
        return new SettingsEndpoint(null, null);
    }

    [Test]
    public async Task Handler_ReturnsSettingsResponse()
    {
        // Arrange

        var endpoint =  new Endpoint<SettingsEndpoint>(null, s=> s.Handle);

        // Act
        var t = SUT.GetType();
        var r = t.Namespace.Replace("Api.Routes.","").Replace(".", "/") + "/" + t.Name.Replace("Endpoint", "");
        var method = t.GetMethod("Handle");
        var requestType = method.GetParameters().FirstOrDefault()?.ParameterType;

        // Get all properties from the request type (IBaseRequest implementer)
        var allProps = requestType?.GetProperties() ?? Array.Empty<PropertyInfo>();
        
        // Get properties with FromRoute attribute
        var routeProps = new List<PropertyInfo>();
        foreach(var p in allProps)
        {
            var attrs = p.GetCustomAttributes(typeof(FromRouteAttribute), false);
            if(attrs != null && attrs.Length > 0)
                routeProps.Add(p);
        }
        
        // Get all property names and types
        var allParameters = allProps.Select(p => new { p.Name, Type = p.PropertyType.Name }).ToList();
        var routeParameters = routeProps.Select(p => new { p.Name, Type = p.PropertyType.Name }).ToList();

        // Assert
        Assert.That(allParameters, Is.Not.Empty, "Should have parameters in request");
        Assert.That(routeParameters, Is.Not.Empty, "Should have route parameters");
        Pass();
    }
}
