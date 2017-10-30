using System;
using Newtonsoft.Json;
using System.IO;
using System.Text;


namespace HansihnBotForTwit
{
    public static class JsonManager<T>
    {

        /// <summary>
        /// Jsonファイルの読み込み
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static T Load(string filename)
        {
            T obj = default(T);

            if(File.Exists(filename))
            {
                using (var stream_r = new StreamReader(filename, Encoding.UTF8))
                {
                    var json = stream_r.ReadToEnd();
                    obj = JsonConvert.DeserializeObject<T>(json);
                }
            }
            else
            {
                throw new FileNotFoundException("Jsonファイルが存在しませんしません");
            }

            return obj;
        }


        /// <summary>
        /// Jsonファイルへの書き込み・ファイルが存在しなければ新規作成
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filename"></param>
        public static void Write(T obj, string  filename)
        {
            using (var stream_w = new StreamWriter(filename, false, Encoding.UTF8))
            {
                var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
                stream_w.Write(json);
            }
        }
    }
}
