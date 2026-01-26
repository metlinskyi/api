namespace UnitTests;
using Microsoft.Extensions.Logging;
/// <summary>
/// Base class for service tests
/// </summary>
/// <typeparam name="TService"></typeparam>
public abstract class UnitTestFor<TService>
{
    protected TService SUT;
    protected Mock<ILogger<TService>> LoggerMock;
    protected abstract TService CreateService();
    [SetUp]
    public virtual void Setup()
    {
        LoggerMock = new Mock<ILogger<TService>>();
        SUT = CreateService();
    }
}