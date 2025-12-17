using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTopics
{
    public static class ParsingExtensions
    {
        private static readonly string nullPlaceholder = "unknown";

        public static int? ToNullableInt(this string value)
        {
            return value == nullPlaceholder ? null : int.Parse(value);
        }

        public static double? ToNullableDouble(this string value)
        {
            return value == nullPlaceholder ? 
                null : double.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
        }

        public static long? ToNullableLong(this string value)
        {
            return value == nullPlaceholder ? null : Convert.ToInt64(value);
        }
    }
}
