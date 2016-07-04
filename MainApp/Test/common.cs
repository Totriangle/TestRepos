using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

/*
namespace MainApp.Test
{
    public interface ICacheFactory
    {
        CacheManager GetCacheManager();
        ICacheItemExpiration[] CreateCacheItemExpiration();
    }
    public abstract class BaseCacheFactory
    {
        public abstract string CacheName
        {
            get;
        }
        public virtual CacheManager GetCacheManager()
        {
            return null;
            //return CacheFactory.GetCacheManager(CacheName) as CacheManager;
        }
        /// <summary>
        /// 获取缓存过期策略，多种过期策略
        /// </summary>
        /// <returns></returns>
        public ICacheItemExpiration[] CreateCacheItemExpiration()
        {
            List<ICacheItemExpiration> cacheItemExpiration = new List<ICacheItemExpiration>();
            //时间间隔多久过期
            / *string slidingSpanName = String.Format("{0}CacheSlidingExpirationTimeSpan", CacheName);
            string slidingSpan = ConfigurationManager.AppSettings[slidingSpanName];
            if (!string.IsNullOrEmpty(slidingSpan))
            {
                TimeSpan slidingExpirationTimeSpan = TimeSpan.Parse(slidingSpan);
                cacheItemExpiration.Add(new SlidingTime(slidingExpirationTimeSpan));
            }
            //
            string absoluteSpanName = String.Format("{0}CacheAbsoluteExpirationTimeSpan", CacheName);
            string absoluteSpan = ConfigurationManager.AppSettings[absoluteSpanName];
            if (!string.IsNullOrEmpty(absoluteSpan))
            {
                TimeSpan absoluteExpirationTimeSpan = TimeSpan.Parse(absoluteSpan);
                cacheItemExpiration.Add(new AbsoluteTime(absoluteExpirationTimeSpan));
            }
            //固定时间过期
            string absoluteTimeName = String.Format("{0}CacheDailyExpirationTime", CacheName);
            string absoluteTime = ConfigurationManager.AppSettings[absoluteTimeName];
            if (!string.IsNullOrEmpty(absoluteTime))
            {
                TimeSpan dailyExpirationTime = TimeSpan.Parse(absoluteTime);

                DateTime absoluteExpirationDateTime = DateTime.Today.Add(dailyExpirationTime);
                if (absoluteExpirationDateTime < DateTime.Now)
                {
                    absoluteExpirationDateTime = absoluteExpirationDateTime.AddDays(1);
                }

                cacheItemExpiration.Add(new AbsoluteTime(absoluteExpirationDateTime));
            }* /
            Console.WriteLine("BaseClass Expiration");
            return cacheItemExpiration.ToArray();
        }

    }

    public class ConfigCacheFactory:BaseCacheFactory,ICacheFactory
    {
        / *因基类中已经实现了接口中的GetCacheManager函数和CreateCacheItemExpiration函数
         * 所以子类可能不再实现，又因GetCacheManager为虚函数，所以子类仍可重写，而缓存策略都使用基类
         * 的所以可以不用修改
         * /
        public override string CacheName
        {
            get
            {
                return "Config";
            }
        }
        public new ICacheItemExpiration[] CreateCacheItemExpiration()
        {
            List<ICacheItemExpiration> list = new List<ICacheItemExpiration>();
            Console.WriteLine("ConfigClass Expiration");
            return list.ToArray();
        }
    }
    public class DomainCacheFactory : BaseCacheFactory, ICacheFactory
    {
        public override string CacheName
        {
            get
            {
                return "Domain";
            }
        }

        public override CacheManager GetCacheManager()
        {
            Console.WriteLine("DomainClass GetCacheManager");
            return null;
        }
    }

    public class Demo
    {
        public static void Test()
        {
            ConfigCacheFactory config = new ConfigCacheFactory();
            DomainCacheFactory domain = new DomainCacheFactory();
            / *List<ICacheFactory> list = new List<ICacheFactory>();
            list.Add(config);
            list.Add(domain);
            foreach(ICacheFactory v in list)
            {
                if (v is BaseCacheFactory)
                    Console.WriteLine("Name:{0}",((BaseCacheFactory)v).CacheName);
                v.GetCacheManager();
                v.CreateCacheItemExpiration();
            }* /
            BaseCacheFactory cache = config;
            Console.WriteLine("Name:{0}", ((BaseCacheFactory)cache).CacheName);
            if (cache is ICacheFactory)
            {
                ((ICacheFactory)cache).GetCacheManager();
                ((ICacheFactory)cache).CreateCacheItemExpiration();
            }
            
        }
    }
}*/
namespace MainApp.Test
{
    #region 基本工厂类
public interface ICacheFactory
    {
        CacheManager GetCacheManager();
        ICacheItemExpiration[] CreateCacheItemExpiration();
    }
    public abstract class BaseCacheFactory:ICacheFactory
    {
        public abstract string CacheName
        {
            get;
        }
        public virtual CacheManager GetCacheManager()
        {
            return null;
            return CacheFactory.GetCacheManager(CacheName) as CacheManager;
        }
        /// <summary>
        /// 获取缓存过期策略，多种过期策略
        /// </summary>
        /// <returns></returns>
        public ICacheItemExpiration[] CreateCacheItemExpiration()
        {
            List<ICacheItemExpiration> cacheItemExpiration = new List<ICacheItemExpiration>();
            //时间间隔多久过期
            string slidingSpanName = String.Format("{0}CacheSlidingExpirationTimeSpan", CacheName);
            string slidingSpan = ConfigurationManager.AppSettings[slidingSpanName];
            if (!string.IsNullOrEmpty(slidingSpan))
            {
                TimeSpan slidingExpirationTimeSpan = TimeSpan.Parse(slidingSpan);
                cacheItemExpiration.Add(new SlidingTime(slidingExpirationTimeSpan));
            }
            //
            string absoluteSpanName = String.Format("{0}CacheAbsoluteExpirationTimeSpan", CacheName);
            string absoluteSpan = ConfigurationManager.AppSettings[absoluteSpanName];
            if (!string.IsNullOrEmpty(absoluteSpan))
            {
                TimeSpan absoluteExpirationTimeSpan = TimeSpan.Parse(absoluteSpan);
                cacheItemExpiration.Add(new AbsoluteTime(absoluteExpirationTimeSpan));
            }
            //固定时间过期
            string absoluteTimeName = String.Format("{0}CacheDailyExpirationTime", CacheName);
            string absoluteTime = ConfigurationManager.AppSettings[absoluteTimeName];
            if (!string.IsNullOrEmpty(absoluteTime))
            {
                TimeSpan dailyExpirationTime = TimeSpan.Parse(absoluteTime);

                DateTime absoluteExpirationDateTime = DateTime.Today.Add(dailyExpirationTime);
                if (absoluteExpirationDateTime < DateTime.Now)
                {
                    absoluteExpirationDateTime = absoluteExpirationDateTime.AddDays(1);
                }

                cacheItemExpiration.Add(new AbsoluteTime(absoluteExpirationDateTime));
            }
            Console.WriteLine("BaseClass Expiration");
            return cacheItemExpiration.ToArray();
        }

    }

    public class ConfigCacheFactory : BaseCacheFactory
    {
        /*?????????????GetCacheManager???CreateCacheItemExpiration??
         * ??????????,??GetCacheManager????,????????,??????????
         * ?????????
         */
        public override string CacheName
        {
            get
            {
                return "Config";
            }
        }
    }
    public class DomainCacheFactory : BaseCacheFactory
    {
        public override string CacheName
        {
            get
            {
                return "Domain";
            }
        }
    }
#endregion

    public class Demo
    {
        public static void Test()
        {
            Demo2();
        }
        public static void Demo1()
        {
            string fileName = "test.xml";
            string rootName = "settings";
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate);
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.CloseOutput = false;//关闭writer时是否关闭基础流
            settings.ConformanceLevel = ConformanceLevel.Fragment;//输出XML文件时的执行等级
            XmlWriter writer = XmlWriter.Create(stream, settings);//如果不加settings，输出等级默认为Document，即结果会有xml版本说明
            writer.WriteWhitespace("\n");//需要换行，否则文件输出时不换行，tab一样也需要在代码中加入
            writer.WriteStartElement(rootName);
            writer.WriteWhitespace("\n");
            for (int i = 0; i < 30; i++)
            {
                writer.WriteWhitespace("\t");
                writer.WriteElementString(string.Format("Name{0}", i), string.Format("Value{0}", i));
                writer.WriteWhitespace("\n");

            }

            writer.WriteEndElement();
            writer.Close();
            stream.Close();
        }
        public static void Demo2()
        {
            
        }
    }

    public class CacheItem
    {
        private IXPathNavigable xmlDoc;

        public IXPathNavigable XmlDoc
        {
            get { return xmlDoc; }
        }
        /// <summary>
        /// 缓存名
        /// </summary>
        public virtual string Name
        {
            get
            {
                XPathNavigator item = null;
                string xpath = string.Format("./Lang[@xml:lang='{0}'/{1}[not(@ID)]","en","Name");
                item = xmlDoc.CreateNavigator().SelectSingleNode(xpath,new XmlNamespaceManager(xmlDoc.CreateNavigator().NameTable));
                return item == null ? string.Empty : item.Value;
            }
        }
        /// <summary>
        /// 缓存缩写
        /// </summary>
        public virtual string Abbrev
        {
            get
            {
                XPathNavigator item = null;
                string xpath = string.Format("./Lang[@xml:lang='{0}'/{1}[not(@ID)]", "en", "Abbrev");
                item = xmlDoc.CreateNavigator().SelectSingleNode(xpath, new XmlNamespaceManager(xmlDoc.CreateNavigator().NameTable));
                return item == null ? string.Empty : item.Value;
            }
        }
        public virtual string Description
        {
            get
            {
                XPathNavigator item = null;
                string xpath = string.Format("./Lang[@xml:lang='{0}'/{1}[not(@ID)]", "en", "Description");
                item = xmlDoc.CreateNavigator().SelectSingleNode(xpath, new XmlNamespaceManager(xmlDoc.CreateNavigator().NameTable));
                return item == null ? string.Empty : item.Value;
            }
        }
        /// <summary>
        /// 缓存项对应存储过程名称
        /// </summary>
        protected virtual string GetProcName
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// 优先级策略
        /// </summary>
        protected virtual CacheItemPriority GetCachePriority
        {
            get
            {
                return CacheItemPriority.Normal;
            }
        }
        public static XmlWriter CreateXmlWriterForReading(MemoryStream ms)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.CloseOutput = false;
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            return XmlWriter.Create(ms, settings);
        }
        public static XmlReader CreateXmlReaderFromMemoryStream(MemoryStream ms)
        {
            ms.Position = 0;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.CloseInput = true;
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            return XmlReader.Create(ms, settings);
        }
        /// <summary>
        /// 聚合XML文档
        /// </summary>
        /// <param name="rootName"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static XmlReader AggregateXmlDocs(string rootName,IEnumerable collection)
        {
            MemoryStream stream = null;
            try
            {
                stream = new MemoryStream();

                using (XmlWriter writer = CreateXmlWriterForReading(stream))
                {
                    if(!string.IsNullOrEmpty(rootName))
                    {
                        writer.WriteStartElement(rootName);//写入根元素
                    }
                    foreach(CacheItem item in collection)
                    {
                        writer.WriteNode(item.xmlDoc.CreateNavigator(), false);
                    }
                    if (!string.IsNullOrEmpty(rootName))
                    {
                        writer.WriteEndElement();//写入根元素结束标记
                    }
                }
                return CreateXmlReaderFromMemoryStream(stream);
            }
            catch (Exception e)
            {
                if (stream != null)
                    stream.Close();
                throw e;
            }
        }
        public XPathNavigator CreateNavitator()
        {
            return this.xmlDoc.CreateNavigator();
        }
        /// <summary>
        /// 是否过期
        /// </summary>
        /// <returns></returns>
        public virtual bool IsExpired()
        {
            return false;
        }
        public virtual void Remove()
        {

        }
        protected void SetXmlDoc(IXPathNavigable xmlDoc)
        {
            if (xmlDoc is XPathDocument)
            {
                this.xmlDoc = xmlDoc.CreateNavigator().SelectSingleNode("/*");
            }
            else
                this.xmlDoc = xmlDoc;
        }
        /// <summary>
        /// 模拟之用，不能产生任何数据
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="paramValues"></param>
        /// <returns></returns>
        public static XmlReader RunSPReturnXmlReader(string storedProcName, params object[] paramValues)
        {
            XmlReader result = null;
            /*Database db = GetDatabase();
            using (DbCommand cmd = GetStoredProcCommand(db, storedProcName, paramValues))
            {
                try
                {
                    using (IDataReader reader = db.ExecuteReader(cmd))
                    {
                        result = SqlHelpers.GetXmlFromDataReader(reader);
                    }
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Number == DEADLOCK)
                    {
                        log.Warn(FormatHelpers.StringFormat("Deadlock detected in proc {0}", storedProcName), sqlEx);
                    }
                    throw;
                }
            }*/

            return result;
        }
        /// <summary>
        /// 从数据库存储过程得到xml数据
        /// </summary>
        /// <returns></returns>
        protected virtual IXPathNavigable GetFromDatabase()
        {
            using (XmlReader reader = RunSPReturnXmlReader(this.GetProcName))
            {
                if (reader.MoveToContent() != XmlNodeType.None)
                {
                    return new XPathDocument(reader);
                }
                else
                    return null;
            }
        }
        /// <summary>
        /// 对象缓冲前的额外初化操作，主流程中应该会调用
        /// </summary>
        protected virtual void Initialize()
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="CF"></typeparam>
    public class CacheItemRefID<T,CF>:CacheItem 
        where T: CacheItemRefID<T,CF>,new()
        where CF:ICacheFactory,new()
    {
        private string refID;
        public string RefID
        {
            get
            {
                return this.refID;
            }
        }
        public static T GetCached(string refID)
        {
            T x = default(T);
            return x;
        }
    }
}