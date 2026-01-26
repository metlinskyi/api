namespace UnitTests.Services;

using Api.Services;

public class UploadServiceTests : UnitTestFor<UploadService>
{
    protected override UploadService CreateService()
    {
        return new UploadService(LoggerMock.Object);
    }

    [Test]
    public async Task Upload()
    {

    }
}
