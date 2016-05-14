using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;

namespace AutoCode.Utils
{
    /// <summary>
    /// 使用DataContractJsonSerializer序列和反序列化
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// 序列化为Json文本
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>Json文本</returns>
        public static string ToJson(object entity)
        {
            if (null != entity)
            {
                DataContractJsonSerializer jsonMgr = new DataContractJsonSerializer(entity.GetType());
                using (MemoryStream mStream = new MemoryStream(1024))
                {
                    jsonMgr.WriteObject(mStream, entity);
                    mStream.Position = 0;
                    TextReader reader = new StreamReader(mStream);
                    return reader.ReadToEnd();
                }
            }
            return null;
        }

        /// <summary>
        /// 反序列化为实例对象
        /// </summary>
        /// <typeparam name="T">实例类型</typeparam>
        /// <param name="json">Json文本</param>
        /// <returns>实例对象</returns>
        public static T FromJson<T>(string json) where T : class
        {
            T entity = default(T);
            if (!string.IsNullOrEmpty(json) && json.Length > 2)
            {

                DataContractJsonSerializer jsonMgr = new DataContractJsonSerializer(typeof(T));
                using (MemoryStream mStream = new MemoryStream(1024))
                {
                    TextWriter writer = new StreamWriter(mStream);
                    writer.Write(json);
                    writer.Flush();
                    mStream.Position = 0;
                    entity = jsonMgr.ReadObject(mStream) as T;
                }
            }
            return entity;
        }
    }
}
