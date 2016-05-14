using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCode.Utils
{
    public static class CommonHelper
    {
        public static Encoding GetCodeEncoding(Config config)
        {
            string encodingStr = config.CodeEncode.Trim();
            return GetEncoding(encodingStr);
        }

        public static Encoding GetProcedureEncoding(Config config)
        {
            string encodingStr = config.ProcedureEncode.Trim();
            return GetEncoding(encodingStr);
        }

        public static Encoding GetEncoding(string encodingStr)
        {
            switch (encodingStr)
            {
                case "GB2312": return Encoding.GetEncoding("GB2312");
                case "UTF8": return Encoding.UTF8;
                case "ASCII": return Encoding.ASCII;
                default: return Encoding.Default;
            }
        }

        public static T FindForeach<T>(this IEnumerable<T> list, Func<T, bool> finder)
        {
            if (list != null && finder != null)
            {
                foreach (var item in list)
                {
                    if (finder(item)) return item;
                }
            }
            return default(T);
        }

        public static List<T> FindAllForeach<T>(this IEnumerable<T> list, Func<T, bool> finder)
        {
            List<T> result = new List<T>();
            if (list != null && finder != null)
            {
                foreach (var item in list)
                {
                    if (finder(item)) result.Add(item);
                }
            }
            return result;
        }
    }
}
