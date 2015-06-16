using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ws.WSAppConfig
{
    internal static class WSAppConfig
    {
        ///<summary>
        ///依据连接串名字connectionName返回数据连接字符串
        ///</summary>
        ///<param name="connectionName"></param>
        ///<returns></returns>
        public static string GetConnectionStringsConfig(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString.ToString();
        }

        public static string GetConnectionProviderName(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ProviderName.ToString();
        }
    }
}
