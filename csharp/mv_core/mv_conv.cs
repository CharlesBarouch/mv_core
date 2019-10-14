using System;

using System.Globalization;

namespace mv_core
{
    public class mv_conv
    {
        public string mv_oconv(string value, string rule)
        {
            string result = "";
            string rule1 = rule.ToUpper().Substring(0, 1);
            string rule2 = rule.Substring(0, 2);
            if (rule1 == "D")
            {
                result = mv_oconv_date(value, rule);
            }
            else if (rule2 == "MT")
            {
                result = mv_oconv_time(value, rule);
            }
            else if (rule1 == "G")
            {

            }
            else { result = ""; }

            return result;
        }
        private string mv_oconv_date(string value, string rule)
        {
            string result = "";
            DateTime dt = new DateTime(1967, 12, 31);
            dt = dt.AddDays(Convert.ToInt16(value));

            //break into elements
            string dt_day = dt.ToString("dd");
            string dt_mo = dt.ToString("MM");
            string dt_yr = dt.ToString("yyyy");

            string dt_day_shortname = dt.ToString("ddd");

            string dt_mo_shortname = dt.ToString("MMM");

            string dt_yr2 = dt_yr.Substring(2, 2);

            string separator = rule.Contains("/") ? "/" : rule.Contains("-") ? "-" : " ";

            string toReturn = string.Concat("{0}", separator, "{1}", separator, "{2}");

            switch (rule)
            {
                case "D2/":
                case "D2-":
                    result = String.Format(toReturn, dt_mo, dt_day, dt_yr2);
                    break;
                case "D2":
                case "D4":
                    result = String.Format(toReturn, dt_day, dt_mo_shortname, (rule == "D2" ? dt_yr2 : dt_yr));
                    break;
                case "D4/":
                case "D4-":
                    result = String.Format(toReturn, dt_mo, dt_day, dt_yr);
                    break;
                case "DD":
                    result = dt_day;
                    break;
                case "DW":
                    result = (Convert.ToInt32(dt.DayOfWeek) * 1).ToString();
                    break;
                case "DWA":
                    result = dt.ToString("dddd");
                    break;
                case "DWB":
                    result = dt_day_shortname;
                    break;
                case "DM":
                    result = dt_mo;
                    break;
                case "DMA":
                    result = dt.ToString("MMMM");
                    break;
                case "DMB":
                    result = dt_mo_shortname;
                    break;
                case "DQ":
                    result = GetQuarter(dt).ToString();
                    break;
                case "DY":
                    result = dt_yr;
                    break;
                case "DY2":
                    result = dt_yr2;
                    break;
                case "DY4":
                    result = dt_yr;
                    break;
            }
            return result.ToUpper();
        }

        private string mv_oconv_time(string value, string rule)
        {
            string result = "";
            Int32 value_time = Convert.ToInt32(value);
            Int32 hour = (value_time / 3600);
            Int32 minute = ((value_time - (hour * 3600)) / 60);
            Int32 second = ((value_time - ((hour * 3600) + (minute * 60))));

            switch (rule)
            {
                case "MT":
                    result = hour.ToString() + ":" + minute.ToString();
                    break;
                case "MTS":
                    result = hour.ToString() + ":" + minute.ToString() + ":" + second.ToString();
                    break;
                case "MTHS":
                    //result = hour.ToString() + ":" + minute.ToString() + ":" + second.ToString() + ampm;
                    result = hour.ToString() + ":" + minute.ToString() + ":" + second.ToString() + ((hour < 13) ? "am" : "pm");
                    break;
            }
 
            return result;
        }

        int GetQuarter(DateTime qdate)
        {
            return Math.Abs((qdate.Month - 1) / 3) + 1;
        }
    }
}
