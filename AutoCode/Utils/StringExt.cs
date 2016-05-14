using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCode.Utils
{
    /// <summary>
    /// 字符串扩展类
    /// </summary>
    public static class StringExt
    {
        /// <summary>
        /// 转化为统一的以冒号(:)分隔的MAC，只是把-、.等替换为:，不做合法判断，结果如:"48:11:22:33:44:fe"
        /// </summary>
        /// <param name="mac">源MAC</param>
        /// <returns>目标MAC</returns>
        public static string ToUnifiedMAC(this string mac)
        {
            return Tools.ToUnifiedMAC(mac);
        }

        /// <summary>
        /// 转化为统一的11位手机号码，有效字符(去除前后空壳)的个数不足11为，否则返回源字符串
        /// </summary>
        /// <param name="phoneNo">手机号码</param>
        /// <returns>11位手机号，否则返回空字符串</returns>
        public static string ToUnifiedPhoneNo(this string phoneNo)
        {
            return Tools.ToUnifiedPhoneNo(phoneNo);
        }

        /// <summary>
        /// 字符串转布尔值
        /// </summary>
        /// <param name="boolStr">要转换的字符串</param>
        /// <param name="_default">转换失败的默认值</param>
        /// <returns>布尔值</returns>
        public static bool ToBoolean(this string boolStr, bool _default)
        {
            return Tools.ParseBoolean(boolStr, _default);
        }

        /// <summary>
        /// 转为字符串，如果为NULL，则用空字符串代替
        /// </summary>
        /// <param name="attr"></param>
        /// <returns></returns>
        public static string ToNotNullString(this string str, string _default)
        {
            if (null == str)
                return _default;
            return str;
        }

        /// <summary>
        /// 转为字符串，如果为NULL，则用空字符串代替
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToNotNullString(this object obj, string _default)
        {
            if (null == obj)
                return _default;
            return obj.ToString();
        }

        /// <summary>
        /// 转为字符串，如果为NULL，则用空字符串代替
        /// </summary>
        /// <param name="attr"></param>
        /// <returns></returns>
        public static string ToNotNullString(this string str)
        {
            return ToNotNullString(str, string.Empty);
        }

        /// <summary>
        /// 转为字符串，如果为NULL，则用空字符串代替
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToNotNullString(this object obj)
        {
            return ToNotNullString(obj, string.Empty);
        }

        /// <summary>
        /// 转为日期，如果为NULL，则用默认值(_default)代替
        /// </summary>
        /// <param name="str"></param>
        /// <param name="_default"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string str, DateTime _default)
        {
            if (str != null)
            {
                return Tools.ParseDt(str, _default);
            }
            return _default;
        }

        /// <summary>
        /// 转为正数，如果为NULL，则用默认值(_default)代替
        /// </summary>
        /// <param name="str"></param>
        /// <param name="_default"></param>
        /// <returns></returns>
        public static int ToInt32(this string str, int _default)
        {
            if (str != null)
            {
                return Tools.ParseInt(str, _default);
            }
            return _default;
        }

        /// <summary>
        /// 转为正数，如果为NULL，则用默认值(_default)代替
        /// </summary>
        /// <param name="str"></param>
        /// <param name="_default"></param>
        /// <returns></returns>
        public static long ToInt64(this string str, long _default)
        {
            if (str != null)
            {
                return Tools.ParseLong(str, _default);
            }
            return _default;
        }

        /// <summary>
        /// 转为浮点数，如果为NULL，则用默认值(_default)代替
        /// </summary>
        /// <param name="str"></param>
        /// <param name="_default"></param>
        /// <returns></returns>
        public static float ToSingle(this string str, float _default)
        {
            if (str != null)
            {
                return Tools.ParseFloat(str, _default);
            }
            return _default;
        }

        /// <summary>
        /// 转为浮点数，如果为NULL，则用默认值(_default)代替
        /// </summary>
        /// <param name="str"></param>
        /// <param name="_default"></param>
        /// <returns></returns>
        public static double ToDouble(this string str, double _default)
        {
            if (str != null)
            {
                return Tools.ParseDouble(str, _default);
            }
            return _default;
        }
    }
}
