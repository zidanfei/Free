using System;
using System.Configuration;
using System.Xml;
using System.Windows.Forms;

namespace LanSee //可以修改成实际项目的命名空间名称
{
    /// <summary>
    /// app.config操作类
    /// </summary>
    public sealed class ConfigHelper
    {
        /// <summary>
        /// 得到AppSettings中的配置字符串信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfigString(string key)
        {
            if (!string.IsNullOrEmpty(ConfigurationSettings.AppSettings[key]))
            {
                return ConfigurationSettings.AppSettings[key];
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 得到ConnectionString中的配置字符串信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConnectionString(string key)
        {
            if (ConfigurationManager.ConnectionStrings[key] != null)
            {
                return ConfigurationManager.ConnectionStrings[key].ConnectionString;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 得到AppSettings中的配置bool信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetConfigBool(string key)
        {
            bool result = false;
            string cfgVal = GetConfigString(key);
            if (!string.IsNullOrEmpty(cfgVal))
            {
                try
                {
                    result = bool.Parse(cfgVal);
                }
                catch (FormatException)
                {
                    // Ignore format exceptions.
                }
            }

            return result;
        }
        /// <summary>
        /// 得到AppSettings中的配置decimal信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static decimal GetConfigDecimal(string key)
        {
            decimal result = 0;
            string cfgVal = GetConfigString(key);
            if (!string.IsNullOrEmpty(cfgVal))
            {
                try
                {
                    result = decimal.Parse(cfgVal);
                }
                catch (FormatException)
                {
                    // Ignore format exceptions.
                }
            }

            return result;
        }
        /// <summary>
        /// 得到AppSettings中的配置int信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetConfigInt(string key)
        {
            int result = 0;
            string cfgVal = GetConfigString(key);
            if (!string.IsNullOrEmpty(cfgVal))
            {
                try
                {
                    result = int.Parse(cfgVal);
                }
                catch (FormatException)
                {
                    // Ignore format exceptions.
                }
            }

            return result;
        }

        /// <summary>
        /// 设置AppSettings中的配置
        /// </summary>
        /// <param name="key">名称</param>
        /// <param name="value">值</param>
        /// <returns>设置成功返回true，失败返回FALSE</returns>
        public static bool SetAppConfig(string key, string value)
        {
            return SetAppConfig(key, value, true);
        }

        /// <summary>
        /// 获得配置文件路径
        /// </summary>
        /// <param name="isWinform"></param>
        /// <returns></returns>
        static string GetConfigPath(bool isWinform)
        {
            string xmlPath = "";
            if (isWinform)
            {
                xmlPath = Application.ProductName + ".exe.config";
            }
            else
            {

                xmlPath = System.Web.HttpRuntime.AppDomainAppPath + "//web.config";
            }
            return xmlPath;
        }

        /// <summary>
        /// 设置AppSettings中的配置
        /// </summary>
        /// <param name="key">名称</param>
        /// <param name="value">值</param>
        /// <param name="isWinform">是否winform程序</param>
        /// <returns>设置成功返回true，失败返回FALSE</returns>
        public static bool SetAppConfig(string key, string value, bool isWinform)
        {

            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(GetConfigPath(isWinform));
                if (xmlDoc.DocumentElement != null)
                {
                    XmlNodeList nl = xmlDoc.DocumentElement.SelectSingleNode("appSettings").SelectNodes("add[@key=\"" + key + "\"]");
                    if (nl != null && nl.Count > 0)
                    {
                        //更新状态
                        foreach (XmlNode node in nl)
                        {
                            ((XmlElement)node).SetAttribute("value", value);
                        }
                    }
                }
                xmlDoc.Save(GetConfigPath(isWinform));
                return true;
            }
            catch //(Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// 设置connectionStrings中的配置
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="providerName"></param>
        /// <returns>设置成功返回true，失败返回FALSE</returns>
        public static bool SetConnectionString(string name, string connectionString, string providerName)
        {
            return SetConnectionString(name, connectionString, providerName, true);
        }

        /// <summary>
        /// 设置connectionStrings中的配置
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="providerName">是否winform程序</param>
        /// <param name="isWinform"></param>
        /// <returns>设置成功返回true，失败返回FALSE</returns>
        public static bool SetConnectionString(string name, string connectionString, string providerName, bool isWinform)
        {
            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(GetConfigPath(isWinform));
                if (xmlDoc.DocumentElement != null)
                {
                    XmlNodeList nl = xmlDoc.DocumentElement.SelectSingleNode("connectionStrings").SelectNodes("add[@name=\"" + name + "\"]");
                    if (nl != null && nl.Count > 0)
                    {
                        //更新状态
                        foreach (XmlNode node in nl)
                        {
                            ((XmlElement)node).SetAttribute("connectionString", connectionString);
                            ((XmlElement)node).SetAttribute("providerName", providerName);
                        }
                    }
                }
                xmlDoc.Save(GetConfigPath(isWinform));
                return true;
            }
            catch //(Exception ex)
            {
                return false;
            }

        }
    }
}
