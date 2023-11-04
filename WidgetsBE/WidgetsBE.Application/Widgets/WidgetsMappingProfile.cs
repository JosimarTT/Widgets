using AutoMapper;
using Google.Protobuf.Collections;
using GrpcLibrary.Widgets;

namespace WidgetsBE.Application.Widgets;

public class WidgetsMappingProfile : Profile
{
    public WidgetsMappingProfile()
    {
        CreateMap<Persistence.Models.Widget, Widget>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
    }
}