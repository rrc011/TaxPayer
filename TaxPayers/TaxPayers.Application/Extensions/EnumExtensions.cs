using System.ComponentModel;
using System.Reflection;

namespace TaxPayers.Application.Extensions
{
    public static class EnumExtensions
    {
        //get enum description
        public static string GetEnumDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                    {
                        return attribute.Description;
                    }
                }
            }
            return value.ToString();
        }
    }
}
