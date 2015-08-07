using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;


namespace sub_download
{
    class HTML_interface
    {

        /// <summary> метод post запроса. Возвращает string содержащий полный текст запрошенной страницы </summary>
        public static string PostReq(string url, string name)
        {
            if (url == null) throw new ArgumentNullException("url");
            WebRequest.DefaultWebProxy = new WebProxy();
            url = @"http://www.fansubs.ru/search.php";

            
            var webReq = new WebClient();

            var data = new NameValueCollection();
            data["query"] = name;

            
            var webResponse = webReq.UploadValues(url, "POST", data);

            return Encoding.Default.GetString(webResponse);
        }

       


        /// <summary> метод http запроса. Возвращает string содержащий полный текст запрошенной страницы </summary>
        public static string GetReq(string url)
        {
            WebRequest.DefaultWebProxy = new WebProxy();


            
            var webReq = WebRequest.Create(url);
            webReq.Credentials = CredentialCache.DefaultCredentials;

            
            var webResponse = webReq.GetResponse();


            var reader = new StreamReader(webResponse.GetResponseStream(), Encoding.Default);


            var html = reader.ReadToEnd();
            reader.Close();
            webResponse.Close();

            return html;
        }


       

        




        /// <summary> класс сождержащий паттерны для парсинга страниц </summary>
        //public static class RegexClass
        //{
        //    public const string FilesInArchivePage = @"<td class=""row3"" width=""290""><font color=""#FFFFFF""><b>(.+)</b></font></td>\r\n<td width=""100"" align=""center"" class=""row3""><a href=""base.php\?cntr=(\d+)""><font color=#FFFFFF>(.+)</font></a></td>\r\n<td width=""100"" align=""center"" class=""row3"">(\d\d\.\d\d\.\d\d)</td>";
        //    public const string RecordsInArchive = @"<li><a href=""base.php\?id=(\d+)"">(.+?) <small>\((.+?)\)</small></a>";

        //    public const string RecordsInForum = @".*?<li><a href=forum/viewtopic.php\?t=(\d+).+?>(.+?) <small>\((.+?)\)</small></a>";

        //    public const string FormatingForumpagePattern = @"</a><br><span style=""font-size: 9px; line-height: normal"">\^ (.+?)</span><br><a";

        //    public const string FilesInForumePage = @"<a href=""./download.php\?id=(\d+)"">(\d\d.\d\d.\d\d) - (.+?)</a><br>";
        //}
    }
}
