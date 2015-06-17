using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Core;
using MongoDB.Driver.Builders;
using ws.WSDocument;
using ws.WSCommon;

namespace ws.WSInit
{

    public class WSMongdbInit
    {

        protected MongoServer MongoDbServer{get;set;}
        protected MongoDatabase MongoDb { get; set; }
        protected MongoCollection DocumentTypeCollection { get; set; }
        #region 数据库连接说明
        //数据库连接
        //要建立数据库连接，就一定要知道服务器的地址、端口等信息。所有的这些信息，我们都使用连接字符串表示。MongoDB的连接字符串格式如下：
        //mongodb://[username:password@]host1[:port1][,host2[:port2],…[,hostN[:portN]]][/[database][?options]]
        //下面看看连接字符串中的各个字段的含义：
        //mongodb://：这个是MongoDB连接字符串的前缀
        //username:password(Optional)：可选项，表示登录用户名和密码，用于完成用户安全验证
        //hostN： 必须的指定至少一个host，表示连接到的MongoDB实例
        //portN(Optional)：可选项，默认连接到27017
        //database(Optional)：如果指定username:password@，连接并验证登陆指定数据库。若不指定，默认打开admin数据库。
        //options(Optional)：可选项，如果不使用/database，则前面需要加上/。所有连接选项都是键值对name=value，键值对之间通过&或;（分号）隔开
        #endregion
        /// <summary>
        /// 初始化
        /// </summary>
        public WSMongdbInit()
        {
            MongoClient client = new MongoClient(WSAppConfig.WSAppConfig.GetConnectionStringsConfig("ws"));
            var serverSettings = MongoServerSettings.FromClientSettings(client.Settings);
            MongoDbServer = client.GetServer();
            MongoDb = MongoDbServer.GetDatabase(WSAppConfig.WSAppConfig.GetConnectionProviderName("ws"));
            DocumentTypeCollection = MongoDb.GetCollection("DocumentType");
            ////获取Users集合  
            //MongoCollection col = db.GetCollection("DocumentType");
            
            //BsonDocument bd = new BsonDocument();
            //bd.Add("DocumentId", DocumentId.GetId());
            //bd.Add("DocumentTypeId", DocumentId.GetId());
            //col.Insert(bd);
            ////查询全部集合里的数据  
            //var result1 = col.FindAllAs<BsonDocument>().ToList();
            //List<BsonValue> listBsonValue = new List<BsonValue>() {1};

            //var result2 = col.FindAs<BsonDocument>(Query.In("age", listBsonValue)).ToList();

            //string aa = DocumentId.GetId();
            //StringBuilder sb = new StringBuilder("");
        }

        public WSCollection GetCollectionById(string Id)
        {
            WSCollection wscol = new WSCollection();
            BsonDocument bd = DocumentTypeCollection.FindOneAs<BsonDocument>(Query.EQ("_id", WSDocumentId.DocumentId));
            string dbname = bd.GetValue("documentdataname").ToString();
            MongoCollection col = MongoDb.GetCollection(dbname);
            foreach(BsonDocument b in col.FindAllAs<BsonDocument>())
            {
                wscol.
            }
            return wscol;
        }

        
    }
}
