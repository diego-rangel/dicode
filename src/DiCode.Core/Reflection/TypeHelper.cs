namespace DiCode.Core.Reflection;

public static class TypeHelper
{
    public static bool IsDefaultValue(object? obj)
    {
        return obj == null || obj.Equals(GetDefaultValue(obj.GetType()));
    }

    public static object? GetDefaultValue(Type type)
    {
        return type.IsValueType ? Activator.CreateInstance(type) : null;
    }
}