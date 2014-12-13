using System;
using System.Configuration;
using System.Xml;
using System.Windows.Forms;

namespace LanSee //�����޸ĳ�ʵ����Ŀ�������ռ�����
{
    /// <summary>
    /// app.config������
    /// </summary>
    public sealed class ConfigHelper
    {
        /// <summary>
        /// �õ�AppSettings�е������ַ�����Ϣ
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
        /// �õ�ConnectionString�е������ַ�����Ϣ
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
        /// �õ�AppSettings�е�����bool��Ϣ
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
        /// �õ�AppSettings�е�����decimal��Ϣ
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
        /// �õ�AppSettings�е�����int��Ϣ
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
        /// ����AppSettings�е�����
        /// </summary>
        /// <param name="key">����</param>
        /// <param name="value">ֵ</param>
        /// <returns>���óɹ�����true��ʧ�ܷ���FALSE</returns>
        public static bool SetAppConfig(string key, string value)
        {
            return SetAppConfig(key, value, true);
        }

        /// <summary>
        /// ��������ļ�·��
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
        /// ����AppSettings�е�����
        /// </summary>
        /// <param name="key">����</param>
        /// <param name="value">ֵ</param>
        /// <param name="isWinform">�Ƿ�winform����</param>
        /// <returns>���óɹ�����true��ʧ�ܷ���FALSE</returns>
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
                        //����״̬
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
        /// ����connectionStrings�е�����
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="connectionString">�����ַ���</param>
        /// <param name="providerName"></param>
        /// <returns>���óɹ�����true��ʧ�ܷ���FALSE</returns>
        public static bool SetConnectionString(string name, string connectionString, string providerName)
        {
            return SetConnectionString(name, connectionString, providerName, true);
        }

        /// <summary>
        /// ����connectionStrings�е�����
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="connectionString">�����ַ���</param>
        /// <param name="providerName">�Ƿ�winform����</param>
        /// <param name="isWinform"></param>
        /// <returns>���óɹ�����true��ʧ�ܷ���FALSE</returns>
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
                        //����״̬
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
