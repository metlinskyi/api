using AutoMapper;

namespace Api.Routes.Web;

public class SettingsProfile : Profile
{
    public SettingsProfile()
    {
        CreateMap<Dictionary<string, string>, SettingsResponse>()
            .ForMember(dest => dest.ApiUrl, opt => opt.MapFrom(src => src[nameof(SettingsResponse.ApiUrl)]));
    }
}  