using System.Reflection;

namespace WidgetsBE.Persistence;

public static class PersistenceAssembly
{
    public static class GetPersistenceAssembly
    {
        public static readonly Assembly Value = typeof(GetPersistenceAssembly).Assembly;
    }
}