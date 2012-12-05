using System.Linq;
using System.Web.Mvc;

namespace ElmahViewer
{
    public static class UrlExtensions
    {
        //to deal with forward slashes in application name parameter... e.g. /LM/W3SVC/...
        //there are most likely better ways to deal with this.
        public static string ForwardSlashEncode(this UrlHelper url, string toEncode)
        {
            return string.IsNullOrEmpty(toEncode) ? string.Empty 
                : toEncode.Contains('/') ? toEncode.Replace("/", "--") : toEncode;
        }
        
        public static string ForwardSlashDecode(this UrlHelper url, string toDecode)
        {
            return  string.IsNullOrEmpty(toDecode) ? string.Empty 
                : toDecode.Contains("--") ? toDecode.Replace("--", "/") : toDecode;
        }
    }
}