using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace AutoCode.Utils
{
    public static class DbHelper
    {
        public static List<T> GetList<T>(DbCommand cmd) where T : class, new()
        {
            List<T> list = new List<T>();
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(ConvertToEntity<T>(reader));
                }
            }
            return list;
        }

        public static bool IsAvailable(IDbConnection conn)
        {
            bool ret = false;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    ret = true;
                }
            }
            catch { }
            return ret;
        }

        public static T ConvertToEntity<T>(IDataReader reader) where T : class, new()
        {
            T entity = new T();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                object val = reader[i];
                if (val != null && val != DBNull.Value && !string.IsNullOrEmpty(val.ToString()))
                {
                    if (typeof(T).GetProperty(reader.GetName(i)) != null)
                    {
                        Type type = typeof(T).GetProperty(reader.GetName(i)).PropertyType;
                        if (type.IsGenericType)
                        {
                            type = type.GetGenericArguments()[0];
                        }
                        if (typeof(IConvertible).IsAssignableFrom(type))
                        {
                            typeof(T).GetProperty(reader.GetName(i)).SetValue(entity, Convert.ChangeType(reader[i], type), null);
                        }

                    }
                }
            }
            return entity;
        }
    }
}
