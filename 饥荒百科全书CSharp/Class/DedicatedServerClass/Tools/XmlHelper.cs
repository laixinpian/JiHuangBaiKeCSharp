﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace 饥荒百科全书CSharp.Class.DedicatedServerClass.Tools
{
  

    /// <summary>
    /// 读写ServerConfig.xml
    /// </summary>
    class XmlHelper
    {
        #region 读写当前游戏平台
        /// <summary>
        /// 读取当前游戏版本[tgp,steam,游侠] 
        /// </summary>
        public static String ReadGamePingTai(string xmlpath)
        {

          
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlpath);
            XmlNode details = xmldoc.SelectSingleNode("configuration/banben/details");
            string s = ((XmlElement)details).GetAttribute("value").Trim();

            if (s.ToLower() == "tgp")
            {
                return "TGP";
            }
            else
            if (s.ToLower() == "steam")
            {
                return "Steam";
            }
            else
            {
                return "游侠";
            }
         

        }

        /// <summary>
        /// 保存当前游戏平台[tgp,steam,游侠]
        /// </summary>
        public static void WriteGamePingTai(string xmlpath, String pingtai)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlpath);
            XmlNode details = xmldoc.SelectSingleNode("configuration/banben/details");

            ((XmlElement)details).SetAttribute("value", pingtai.ToString());

            xmldoc.Save(xmlpath);

        }

        #endregion

        #region 汉化
        /// <summary>
        /// 读取汉化
        /// </summary>
        public static Dictionary<string, string> ReadHanhua(string xmlpath)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlpath);
            XmlNodeList details = xmldoc.SelectNodes("configuration/hanhua/details");

            foreach (XmlNode item in details)
            {
                string english = ((XmlElement)item).GetAttribute("english").Trim();
                string chinese = ((XmlElement)item).GetAttribute("chinese").Trim();
                dic[english] = chinese;
            }
            return dic;
        }

        #endregion

        #region 读写 客户端,服务器 路径
        /// <summary>
        /// 读取客户端路径
        /// </summary>
        public static string ReadClientPath(string xmlpath, String pingtai)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlpath);

            if (pingtai == "Steam")
            {
                XmlNode details = xmldoc.SelectSingleNode("configuration/path/steam/client");
                return ((XmlElement)details).GetAttribute("path");
            }
            if (pingtai == "TGP")
            {
                XmlNode details = xmldoc.SelectSingleNode("configuration/path/tgp/client");
                return ((XmlElement)details).GetAttribute("path");
            }

            if (pingtai == "游侠")
            {
                XmlNode details = xmldoc.SelectSingleNode("configuration/path/youxia/client");
                return ((XmlElement)details).GetAttribute("path");
            }

            return String.Empty;
        }

        /// <summary>
        /// 设置客户端路径
        /// </summary>
        public static void WriteClientPath(string xmlpath, string ClientPath, String pingtai)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlpath);

            if (pingtai == "Steam")
            {
                XmlNode details = xmldoc.SelectSingleNode("configuration/path/steam/client");
                ((XmlElement)details).SetAttribute("path", ClientPath);
            }
            if (pingtai == "TGP")
            {
                XmlNode details = xmldoc.SelectSingleNode("configuration/path/tgp/client");
                ((XmlElement)details).SetAttribute("path", ClientPath);
            }

            if (pingtai == "游侠")
            {
                XmlNode details = xmldoc.SelectSingleNode("configuration/path/youxia/client");
                ((XmlElement)details).SetAttribute("path", ClientPath);
            }
            xmldoc.Save(xmlpath);

        }

        /// <summary>
        /// 读取服务端路径
        /// </summary>
        public static string ReadServerPath(string xmlpath, String pingtai)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlpath);

            if (pingtai == "Steam")
            {
                XmlNode details = xmldoc.SelectSingleNode("configuration/path/steam/server");
                return ((XmlElement)details).GetAttribute("path");
            }
            if (pingtai == "TGP")
            {
                XmlNode details = xmldoc.SelectSingleNode("configuration/path/tgp/server");
                return ((XmlElement)details).GetAttribute("path");
            }

            if (pingtai == "游侠")
            {
                XmlNode details = xmldoc.SelectSingleNode("configuration/path/youxia/server");
                return ((XmlElement)details).GetAttribute("path");
            }

            return String.Empty;
        }

        /// <summary>
        /// 设置服务端路径
        /// </summary>
        public static void WriteServerPath(string xmlpath, string ServerPath, String pingtai)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlpath);

            if (pingtai == "Steam")
            {
                XmlNode details = xmldoc.SelectSingleNode("configuration/path/steam/server");
                ((XmlElement)details).SetAttribute("path", ServerPath);
            }
            if (pingtai == "TGP")
            {
                XmlNode details = xmldoc.SelectSingleNode("configuration/path/tgp/server");
                ((XmlElement)details).SetAttribute("path", ServerPath);
            }

            if (pingtai == "游侠")
            {
                XmlNode details = xmldoc.SelectSingleNode("configuration/path/youxia/server");
                ((XmlElement)details).SetAttribute("path", ServerPath);
            }
            xmldoc.Save(xmlpath);


        }

        #endregion

    }
}
