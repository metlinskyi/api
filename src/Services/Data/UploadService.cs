using Grpc.Core;

namespace Api.Services.Data;

public class UploadService : Upload.UploadBase, IService
{
    private readonly ILogger<UploadService> _logger;
    public UploadService(ILogger<UploadService> logger)
    {
        _logger = logger;
    }

    public override Task<UploadResponse> Upload(UploadRequest request, IServerStreamWriter<UploadResponse> responseStream, ServerCallContext context)
    {
        return Task.FromResult(new UploadResponse
        {

        });
    }
}
