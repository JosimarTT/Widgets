using AutoMapper;
using Google.Protobuf.Collections;

namespace WidgetsBE.Shared.AutoMapper;

public class SharedProfile:Profile
{
    public SharedProfile()
    {CreateMap(typeof(IEnumerable<>), typeof(RepeatedField<>)).ConvertUsing(typeof(EnumerableToRepeatedFieldTypeConverter<,>));
        CreateMap(typeof(RepeatedField<>), typeof(List<>)).ConvertUsing(typeof(RepeatedFieldToListTypeConverter<,>));
    }
}

internal class EnumerableToRepeatedFieldTypeConverter<TITemSource, TITemDest> : ITypeConverter<IEnumerable<TITemSource>, RepeatedField<TITemDest>>
{
    public RepeatedField<TITemDest> Convert(IEnumerable<TITemSource> source, RepeatedField<TITemDest> destination, ResolutionContext context)
    {
        destination ??= new RepeatedField<TITemDest>();
        foreach (var item in source)
            destination.Add(context.Mapper.Map<TITemDest>(item));
        return destination;
    }
}

internal class RepeatedFieldToListTypeConverter<TITemSource, TITemDest> : ITypeConverter<RepeatedField<TITemSource>, List<TITemDest>>
{
    public List<TITemDest> Convert(RepeatedField<TITemSource> source, List<TITemDest> destination, ResolutionContext context)
    {
        destination ??= new List<TITemDest>();
        destination.AddRange(source.Select(item => context.Mapper.Map<TITemDest>(item)));
        return destination;
    }
}