using System;

namespace Mobiroller.Core.Helpers
{
    public static class JsonParseHelperItalian
    {
        public static DateTime ParseEventDate(string timeString, string eventString)
        {
            try
            {
                var month = DateTime.ParseExact(timeString.Split(" ")[1], "MMMM", System.Threading.Thread.CurrentThread.CurrentCulture =
                    new System.Globalization.CultureInfo("it-IT")).Month;
                return new DateTime(Convert.ToInt32(eventString.Split(" ")[0]), month, Convert.ToInt16(timeString.Split(" ")[0]));
            }
            catch (Exception ex)
            {
                return new DateTime();
            }
        }

        public static string utf8Converter(string text)
        {
            return text.Replace("ğ", "g");
        }
    }
}
