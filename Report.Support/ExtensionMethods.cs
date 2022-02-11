using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Support
{
    public class ExtensionMethods
    {

        public static string ToTimeFormat(string format)
        {
            string massege = string.Empty;
            string dateData = string.Empty;
            if (format != null)
            {
                dateData = format.ToString().Trim();
                DateTime dt = DateTime.Parse(dateData);
                massege = dt.ToString("HH:mm");
            }
            else
                massege = "Invalid";

            return massege;
        }
        public static string ToDateFormat(string format)
        {
            string massege = string.Empty;
            string dateData = string.Empty;
            if (format != null)
                dateData = format.ToString().Trim();

            bool result = DateTime.TryParseExact(dateData, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime);
            if (result)
                massege = dateTime.ToString("MM-dd-yyyy");
            else
                massege = "Invalid";

            return massege;

        }
    }
}
