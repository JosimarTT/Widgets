using System.Reflection;

namespace WidgetsBE.Shared;

public static class SharedAssembly
{
    public static class GetSharedAssembly
    {
        public static readonly Assembly Value = typeof(GetSharedAssembly).Assembly;
    }
}