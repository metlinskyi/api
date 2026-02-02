namespace Api.Services;

using Data;
using Images;
using Web;
/// <summary>
/// Extension methods to map gRPC services.
/// </summary>
public static class Mapping
{
    public static void MapServices(this WebApplication ____)
    {
        
#region  Auth

        ____.MapGrpcService<GreeterService>();

#endregion 

#region Data

        ____.MapGrpcService<UploadService>()
            .RequireAuthorization();

#endregion

#region Images

        ____.MapMediatorEndpoint<ImageOfTheDayRequest>()
            .AsGet()
            .RequireAuthorization();

#endregion

#region Web

        ____.MapMediatorEndpoint<SettingsRequest>()
            .AsGet();

#endregion   

    }
}