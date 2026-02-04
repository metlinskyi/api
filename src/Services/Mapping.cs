namespace Api.Services;

using Bot;
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

#region Bot

        ____.MapEndpoint<IBotService>(s => s.GetSettings)
            .AsGet()
            //.RequireAuthorization()
            ;   
#endregion

#region Data

        ____.MapGrpcService<UploadService>()
            .RequireAuthorization();

#endregion

#region Images

        ____.MapEndpoint<ImageOfTheDayRequest>()
            .AsPost()
            //.RequireAuthorization()
            ;

#endregion

#region Web

        ____.MapEndpoint<SettingsRequest>()
            .AsGet();

#endregion   

    }
}