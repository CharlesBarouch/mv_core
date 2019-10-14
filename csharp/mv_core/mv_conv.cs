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
            DateTime dt = new DateTime(1967, 12, 31, 0, 0, 0);
            dt = dt.AddDays(Convert.ToDouble(value));
            //break into elements
            string dt_day = dt.Day.ToString();
            string dt_mo = dt.Month.ToString();
            string dt_yr = dt.Year.ToString();

            string dt_day_name = dt.DayOfWeek.ToString();
            string dt_day_shortname = dt_day_name.Substring(0, 3);
            string dt_day_number = (Convert.ToInt32(dt.DayOfWeek) * 1).ToString();

            string dt_mo_name = dt.ToString("MMMM");
            string dt_mo_shortname = dt.ToString("MMM");

            string dt_quarter = GetQuarter(dt).ToString();

            string dt_yr2 = dt_yr.Substring(2, 2);

            switch (rule)
            {
                case "D2/":
                    result = dt_mo + "/" + dt_day + "/" + dt_yr2;
                    break;
                case "D2-":
                    result = dt_mo + "-" + dt_day + "-" + dt_yr2;
                    break;
                case "D2":
                    result = dt_day + " " + dt_mo_shortname + " " + dt_yr2;
                    break;
                case "D4/":
                    result = dt_mo + "/" + dt_day + "/" + dt_yr;
                    break;
                case "D4-":
                    result = dt_mo + "-" + dt_day + "-" + dt_yr;
                    break;
                case "D4":
                    result = dt_day + " " + dt_mo_shortname + " " + dt_yr;
                    break;
                case "DD":
                    result = dt_day;
                    break;
                case "DW":
                    result = dt_day_number;
                    break;
                case "DWA":
                    result = dt_day_name;
                    break;
                case "DWB":
                    result = dt_day_shortname;
                    break;
                case "DM":
                    result = dt_mo;
                    break;
                case "DMA":
                    result = dt_mo_name;
                    break;
                case "DMB":
                    result = dt_mo_shortname;
                    break;
                case "DQ":
                    result = dt_quarter;
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
            string ampm;
            if (hour < 13)
            {
                ampm = "am";
            }
            else
            {
                ampm = "pm";
            }
            switch (rule)
            {
                case "MT":
                    result = hour.ToString() + ":" + minute.ToString();
                    break;
                case "MTS":
                    result = hour.ToString() + ":" + minute.ToString() + ":" + second.ToString();
                    break;
                case "MTHS":
                    result = hour.ToString() + ":" + minute.ToString() + ":" + second.ToString() + ampm;
                    break;
            }
 
            return result;
        }
        int GetQuarter(DateTime qdate)
        {
            int month = qdate.Month - 1;
            int quarter = Math.Abs(month / 3) + 1;
            return quarter;
        }
    }
}
