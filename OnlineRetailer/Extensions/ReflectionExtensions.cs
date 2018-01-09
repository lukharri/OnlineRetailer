using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineRetailer.Extensions
{
    public static class ReflectionExtensions
    {
        // return the value of the property of the entity passed into the function
        public static string GetPropertyValue<T>(this T item, string propertyName)
        {
            return item.GetType().GetProperty(propertyName).GetValue(item, null).ToString();
        }
    }
}