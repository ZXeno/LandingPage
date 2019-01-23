using System;
using System.Web;

namespace LandingPage.HelperClasses
{
    public static class StringHelper
    {
        public static string HtmlFormattedString(string inputString)
        {
            return inputString == null ? null : HttpUtility.HtmlEncode(inputString).Replace(Environment.NewLine, "<br />");
        }
    }
}
