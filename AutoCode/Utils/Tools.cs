using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace AutoCode.Utils
{
    /// <summary>
    /// 通用工具
    /// </summary>
    public class Tools
    {
        /// <summary>
        /// 时间转为字符串，如2013-11-12 08:30:23
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <returns>时间字符串</returns>
        public static string ToMyString(DateTime? dateTime)
        {
            string result = string.Empty;
            if (null != dateTime && dateTime.HasValue)
            {
                result = dateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            return result;
        }

        /// <summary>
        /// 时间转为字符串，精确到毫秒，如2013-11-12 08:30:23.889
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <returns>时间字符串</returns>
        public static string ToMyMsecString(DateTime? dateTime)
        {
            string result = string.Empty;
            if (null != dateTime && dateTime.HasValue)
            {
                result = dateTime.Value.ToString("yyyy-MM-dd HH:mm:ss.fff");
            }
            return result;
        }

        /// <summary>
        /// 时间转为字符串，如2013-11-12 08:30:23
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <returns>时间字符串</returns>
        public static string ToMyString(DateTime dateTime)
        {
            string result = string.Empty;
            result = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            return result;
        }

        /// <summary>
        /// 时间转为字符串，精确到毫秒，如2013-11-12 08:30:23.889
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <returns>时间字符串</returns>
        public static string ToMyMsecString(DateTime dateTime)
        {
            string result = string.Empty;
            result = dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            return result;
        }

        /// <summary>
        /// 字符串转换日期
        /// </summary>
        /// <param name="dateStr">字符串格式日期</param>
        /// <param name="_default">转换失败的默认时间</param>
        /// <returns>日期DateTime</returns>
        public static DateTime ParseDt(string dateStr, DateTime _default)
        {
            DateTime tmpDate = DateTime.Now;
            if (DateTime.TryParse(dateStr, out tmpDate))
                return tmpDate;
            else
                return _default;
        }

        /// <summary>
        /// 字符串转换日期,失败返回NULL
        /// </summary>
        /// <param name="dateStr">字符串格式日期</param>
        /// <returns>日期DateTime?</returns>
        public static DateTime? ParseDtOrNull(string dateStr)
        {
            DateTime tmpDate = DateTime.Now;
            if (DateTime.TryParse(dateStr, out tmpDate))
                return tmpDate;
            else
                return null;
        }

        /// <summary>
        /// 字符串转整形数据
        /// </summary>
        /// <param name="intStr">字符串格式整形</param>
        /// <param name="_default">转换失败的默认数字</param>
        /// <returns>整形</returns>
        public static int ParseInt(string intStr, int _default)
        {
            int tmpInt = 0;
            if (Int32.TryParse(intStr, out tmpInt))
                return tmpInt;
            else
                return _default;
        }

        /// <summary>
        /// 字符串转整形数据
        /// </summary>
        /// <param name="longStr">字符串格式整形</param>
        /// <param name="_default">转换失败的默认数字</param>
        /// <returns>长整形</returns>
        public static long ParseLong(string longStr, long _default)
        {
            long tmpInt = 0;
            if (Int64.TryParse(longStr, out tmpInt))
                return tmpInt;
            else
                return _default;
        }

        /// <summary>
        /// 字符串转浮点数据
        /// </summary>
        /// <param name="floatStr">字符串格式浮点数</param>
        /// <param name="_default">转换失败的默认数字</param>
        /// <returns>浮点数</returns>
        public static float ParseFloat(string floatStr, float _default)
        {
            float tmpInt = 0;
            if (Single.TryParse(floatStr, out tmpInt))
                return tmpInt;
            else
                return _default;
        }

        /// <summary>
        /// 字符串转浮点数据
        /// </summary>
        /// <param name="doubleStr">字符串格式浮点数</param>
        /// <param name="_default">转换失败的默认数字</param>
        /// <returns>浮点数</returns>
        public static double ParseDouble(string doubleStr, double _default)
        {
            double tmpInt = 0;
            if (Double.TryParse(doubleStr, out tmpInt))
                return tmpInt;
            else
                return _default;
        }

        /// <summary>
        /// 字符串转十进制数
        /// </summary>
        /// <param name="decimalStr">字符串格式十进制数</param>
        /// <param name="_default">转换失败的默认数字</param>
        /// <returns>十进制数</returns>
        public static decimal ParseDecimal(string decimalStr, decimal _default)
        {
            decimal tmpInt = 0;
            if (decimal.TryParse(decimalStr, out tmpInt))
                return tmpInt;
            else
                return _default;
        }

        /// <summary>
        /// 字符串转布尔值
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="_default">转换失败的默认值</param>
        /// <returns>布尔值</returns>
        public static bool ParseBoolean(string str, bool _default)
        {
            bool tmp = false;
            if (Boolean.TryParse(str, out tmp))
                return tmp;
            else
                return _default;
        }

        /// <summary>
        /// 转化为统一的以冒号(:)分隔的MAC，只是把-、.等替换为:，不做合法判断，结果如:"48:11:22:33:44:fe"
        /// </summary>
        /// <param name="mac">源MAC</param>
        /// <returns>目标MAC</returns>
        public static string ToUnifiedMAC(string mac)
        {
            if (!string.IsNullOrEmpty(mac))
            {
                return mac.Trim().Replace('-', ':').Replace('.', ':').ToLower();
            }
            return mac;
        }

        /// <summary>
        /// 转化为统一的11位手机号码，有效字符(去除前后空壳)的个数不足11为，否则返回源字符串
        /// </summary>
        /// <param name="phoneNo">手机号码</param>
        /// <returns>11位手机号，否则返回空字符串</returns>
        public static string ToUnifiedPhoneNo(string phoneNo)
        {
            if (!string.IsNullOrEmpty(phoneNo))
            {
                string tmpPhone = phoneNo.Trim();
                if (tmpPhone.Length >= 11)
                {
                    return tmpPhone.Substring(tmpPhone.Length - 11, 11);
                }
            }
            return phoneNo;
        }

        public static string FirstLetterToUpper(string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                short bs = (short)'A';
                //short be = (short)'Z';
                short ls = (short)'a';
                short le = (short)'z';
                short first = (short)str[0];
                if (first >= ls && first <= le)
                {
                    char ret = (char)(first - (ls - bs));
                    str = ret + str.Substring(1);
                }
            }
            return str;
        }

        public static string FirstLetterToLower(string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                short bs = (short)'A';
                short be = (short)'Z';
                short ls = (short)'a';
                //short le = (short)'z';
                short first = (short)str[0];
                if (first >= bs && first <= be)
                {
                    char ret = (char)(first + (ls - bs));
                    str = ret + str.Substring(1);
                }
            }
            return str;
        }
    }
}
