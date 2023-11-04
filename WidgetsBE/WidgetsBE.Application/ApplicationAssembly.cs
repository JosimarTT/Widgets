using System.Reflection;

namespace WidgetsBE.Application;

public static class ApplicationAssembly
{
    public static class GetApplicationAssembly
    {
        public static readonly Assembly Value = typeof(GetApplicationAssembly).Assembly;
    }
}