using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace yiran.Tools
{
    public class ToolBase
    {
        private static IConfiguration _configuration;

        static ToolBase()
        {
            //在当前目录或者根目录中寻找appsettings.json文件
            var fileName = "appsettings.json";

            var directory = AppContext.BaseDirectory;
            directory = directory.Replace("\\", "/");

            var filePath = $"{directory}/{fileName}";
            if (!File.Exists(filePath))
            {
                var length = directory.IndexOf("/bin");
                filePath = $"{directory.Substring(0, length)}/{fileName}";
            }

            var builder = new ConfigurationBuilder()
                .AddJsonFile(filePath, false, true);

            _configuration = builder.Build();
        }

        public static string GetSectionValue(string key)
        {
            return _configuration.GetSection(key).Value;
        }

        #region Md5加密
        /// <summary>
        /// Md5加密
        /// </summary>
        /// <param name="mingwen">返回加密后的密文</param>
        public static string EncryptByMd5(string mingwen)
        {
            MD5 mD = new MD5CryptoServiceProvider();
            byte[] array = mD.ComputeHash(Encoding.UTF8.GetBytes(mingwen));
            StringBuilder stringBuilder = new StringBuilder();
            byte[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                byte b = array2[i];
                stringBuilder.Append(b.ToString("x").PadLeft(2, '0'));
            }
            return stringBuilder.ToString();
        }
        #endregion

    }
}
