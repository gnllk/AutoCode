using System;
using System.Text;

namespace AutoCode.Utils
{
    /// <summary>
    /// String functions extention
    /// </summary>
    public static class StringExt
    {
        /// <summary>
        /// To unitfied MAC address witch separated by ":", like: "48:11:22:33:44:fe"
        /// </summary>
        /// <param name="mac">source MAC</param>
        /// <returns>unitfied MAC</returns>
        public static string ToUnifiedMAC(this string mac)
        {
            return Tools.ToUnifiedMAC(mac);
        }

        /// <summary>
        /// To bool
        /// </summary>
        /// <param name="boolStr">bool string</param>
        /// <param name="_default">defaule value</param>
        /// <returns>bool</returns>
        public static bool ToBoolean(this string boolStr, bool _default)
        {
            return Tools.ParseBoolean(boolStr, _default);
        }

        /// <summary>
        /// To not null string, return _default string if string is null
        /// </summary>
        /// <param name="str">sourcee string</param>
        /// <param name="_default">default value</param>
        /// <returns>string</returns>
        public static string ToNotNullString(this string str, string _default)
        {
            if (null == str)
                return _default;
            return str;
        }

        /// <summary>
        /// To not null string, return _default string if object is null
        /// </summary>
        /// <param name="obj">any object</param>
        /// <param name="_default">default value</param>
        /// <returns>string</returns>
        public static string ToNotNullString(this object obj, string _default)
        {
            if (null == obj)
                return _default;
            return obj.ToString();
        }

        /// <summary>
        /// To not null string, return empty string if string is null
        /// </summary>
        /// <param name="str">source string</param>
        /// <returns>string</returns>
        public static string ToNotNullString(this string str)
        {
            return ToNotNullString(str, string.Empty);
        }

        /// <summary>
        /// To not null string, return empty string if object is null
        /// </summary>
        /// <param name="obj">any object</param>
        /// <returns>string</returns>
        public static string ToNotNullString(this object obj)
        {
            return ToNotNullString(obj, string.Empty);
        }

        /// <summary>
        /// To DateTime
        /// </summary>
        /// <param name="str">datetime string</param>
        /// <param name="_default">default value</param>
        /// <returns>DateTime</returns>
        public static DateTime ToDateTime(this string str, DateTime _default)
        {
            if (str != null)
            {
                return Tools.ParseDt(str, _default);
            }
            return _default;
        }

        /// <summary>
        /// To Int32
        /// </summary>
        /// <param name="str">number string</param>
        /// <param name="_default">default value</param>
        /// <returns>number</returns>
        public static int ToInt32(this string str, int _default)
        {
            if (str != null)
            {
                return Tools.ParseInt(str, _default);
            }
            return _default;
        }

        /// <summary>
        /// To Int64
        /// </summary>
        /// <param name="str">number string</param>
        /// <param name="_default">default value</param>
        /// <returns>number</returns>
        public static long ToInt64(this string str, long _default)
        {
            if (str != null)
            {
                return Tools.ParseLong(str, _default);
            }
            return _default;
        }

        /// <summary>
        /// To float
        /// </summary>
        /// <param name="str">number string</param>
        /// <param name="_default">default value</param>
        /// <returns>number</returns>
        public static float ToSingle(this string str, float _default)
        {
            if (str != null)
            {
                return Tools.ParseFloat(str, _default);
            }
            return _default;
        }

        /// <summary>
        /// To double
        /// </summary>
        /// <param name="str">number string</param>
        /// <param name="_default">default value</param>
        /// <returns>number</returns>
        public static double ToDouble(this string str, double _default)
        {
            if (str != null)
            {
                return Tools.ParseDouble(str, _default);
            }
            return _default;
        }

        /// <summary>
        /// Replace a string which start with the oldValue
        /// </summary>
        /// <param name="src">source string</param>
        /// <param name="oldValue">old string</param>
        /// <param name="newValue">new string</param>
        /// <returns>string</returns>
        public static string ReplaceStart(this string src, string oldValue, string newValue)
        {
            if (string.IsNullOrEmpty(src)) return src;
            if (string.IsNullOrEmpty(oldValue)) return src;
            if (!src.StartsWith(oldValue)) return src;
            return newValue + src.Substring(oldValue.Length);
        }

        /// <summary>
        /// Replace a string which end with the oldValue
        /// </summary>
        /// <param name="src">source string</param>
        /// <param name="oldValue">old string</param>
        /// <param name="newValue">new string</param>
        /// <returns>string</returns>
        public static string ReplaceEnd(this string src, string oldValue, string newValue)
        {
            if (string.IsNullOrEmpty(src)) return src;
            if (string.IsNullOrEmpty(oldValue)) return src;
            if (!src.EndsWith(oldValue)) return src;
            return src.Substring(0, src.Length - oldValue.Length) + newValue;
        }

        /// <summary>
        /// To upper
        /// </summary>
        /// <param name="src">source string</param>
        /// <param name="startIndex">start index</param>
        /// <param name="count">count</param>
        /// <returns>string</returns>
        public static string ToSomeUpper(this string src, int startIndex = 0, int count = 1)
        {
            return ToUpperOrLower(src, startIndex, count, true);
        }

        private static string ToUpperOrLower(this string src, int startIndex = 0, int count = 1, bool toUpper = true)
        {
            if (string.IsNullOrWhiteSpace(src)) return src;
            if (count < 1) return src;
            if (startIndex < 0 || startIndex >= src.Length) return src;

            string first = startIndex == 0 ? string.Empty : src.Substring(0, startIndex);
            string upper = toUpper ? src.Substring(startIndex, count).ToUpper() : src.Substring(startIndex, count).ToLower();
            string last = startIndex + count > src.Length ? string.Empty : src.Substring(startIndex + count);

            return first + upper + last;
        }

        /// <summary>
        /// To lower
        /// </summary>
        /// <param name="src">source string</param>
        /// <param name="startIndex">start index</param>
        /// <param name="count">count</param>
        /// <returns>string</returns>
        public static string ToSomeLower(this string src, int startIndex = 0, int count = 1)
        {
            return ToUpperOrLower(src, startIndex, count, false);
        }
    }
}
