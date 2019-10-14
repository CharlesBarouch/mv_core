using System;
using mv_core;

namespace mv_oconv_test
{
    class Program
    {
        static void Main(string[] args)
        {
            string test_date = "18915";
            var conv = new mv_core.mv_conv();
            string oconv_date = conv.mv_oconv(test_date, "D2/");
            Console.WriteLine("D2/ - " + oconv_date);
            oconv_date = conv.mv_oconv(test_date, "D2-");
            Console.WriteLine("D2- - " + oconv_date);
            oconv_date = conv.mv_oconv(test_date, "D2");
            Console.WriteLine("D2  - " + oconv_date);
            oconv_date = conv.mv_oconv(test_date, "D4/");
            Console.WriteLine("D4/ - " + oconv_date);
            oconv_date = conv.mv_oconv(test_date, "D4-");
            Console.WriteLine("D4- - " + oconv_date);
            oconv_date = conv.mv_oconv(test_date, "D4");
            Console.WriteLine("D4  - " + oconv_date);
            oconv_date = conv.mv_oconv(test_date, "DD");
            Console.WriteLine("DD  - " + oconv_date);
            oconv_date = conv.mv_oconv(test_date, "DW");
            Console.WriteLine("DW  - " + oconv_date);
            oconv_date = conv.mv_oconv(test_date, "DWA");
            Console.WriteLine("DWA - " + oconv_date);
            oconv_date = conv.mv_oconv(test_date, "DWB");
            Console.WriteLine("DWB - " + oconv_date);
            oconv_date = conv.mv_oconv(test_date, "DM");
            Console.WriteLine("DM  - " + oconv_date);
            oconv_date = conv.mv_oconv(test_date, "DMA");
            Console.WriteLine("DMA - " + oconv_date);
            oconv_date = conv.mv_oconv(test_date, "DMB");
            Console.WriteLine("DMB - " + oconv_date);
            oconv_date = conv.mv_oconv(test_date, "DQ");
            Console.WriteLine("DQ  - " + oconv_date);
            oconv_date = conv.mv_oconv(test_date, "DY");
            Console.WriteLine("DY  - " + oconv_date);
            oconv_date = conv.mv_oconv(test_date, "DY2");
            Console.WriteLine("Dy2 - " + oconv_date);
            oconv_date = conv.mv_oconv(test_date, "DY4");
            Console.WriteLine("DY4 - " + oconv_date);

            string test_time = "12519";
            string oconv_time = conv.mv_oconv(test_time, "MT");
            Console.WriteLine("MTS - " + oconv_time);
            oconv_time = conv.mv_oconv(test_time, "MTS");
            Console.WriteLine("MT  - " + oconv_time);
            oconv_time = conv.mv_oconv(test_time, "MTHS");
            Console.WriteLine("MTHS- " + oconv_time);

            var ans = Console.ReadLine();
        }
    }
}
