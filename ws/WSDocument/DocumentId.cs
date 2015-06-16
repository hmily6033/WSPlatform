using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ws.WSDocument
{
    /// <summary>
    /// 产生文档ID
    /// </summary>
    internal static class DocumentId
    {
        public static string GetId()
        {
            return BsonObjectId.GenerateNewId().ToString();
        }
    }
}
