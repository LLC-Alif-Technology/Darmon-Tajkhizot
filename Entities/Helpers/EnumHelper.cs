using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Entities.Helpers
{
    public static class EnumHelper
    {
        public static string GetEnumDescription(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            if (fi.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}
