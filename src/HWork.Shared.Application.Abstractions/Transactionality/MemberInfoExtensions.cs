using System.Reflection;

namespace HWork.Shared.Application.Abstractions.Transactionality;

internal static class MemberInfoExtensions
{
    public static Type GetMemberType(this MemberInfo member)
    {
        return member switch
        {
            PropertyInfo property => property.PropertyType,
            FieldInfo field => field.FieldType,
            _ => throw new ArgumentException("Member is not a field or property", nameof(member))
        };
    }

    public static object? GetValue(this MemberInfo member, object obj)
    {
        return member switch
        {
            PropertyInfo property => property.GetValue(obj),
            FieldInfo field => field.GetValue(obj),
            _ => throw new ArgumentException("Member is not a field or property", nameof(member))
        };
    }
    
    public static bool ImplementsGenericInterface(this Type type, Type genericInterface)
    {
        return type.GetInterfaces()
            .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == genericInterface);
    }
}
