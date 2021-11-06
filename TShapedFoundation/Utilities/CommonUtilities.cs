using System;
using System.Web;
using TShapedFoundation.Common;

namespace TShapedFoundation.Utilities
{
    public static class CommonUtilities
    {
        public static string CreateEmailAddress(string emailName, string gmailAddress)
        {
            return $"{emailName}{DateTime.Now.ToString("yyMMddHHmmss")}{gmailAddress}";
        }

        public static string GetQueryParam(string url, string queryParameter)
        {
            Uri theUri = new Uri(url);
            return HttpUtility.ParseQueryString(theUri.Query).Get(queryParameter);
        }
    }
}
