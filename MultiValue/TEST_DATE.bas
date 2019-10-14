     PROGRAM TEST_DATE
     * Test date format for C# comparison
     * Written specically for OpenQM
     *
     InputDate = FIELD(@SENTENCE,' ',2)
     IF InputDate NE '' THEN
        IF InputDate MATCHES '0N' THEN
           TestDate = InputDate
        END ELSE
           TestDate = ICONV(InputDate,'D')
           IF NOT(TestDate MATCHES '0N) THEN STOP
        END
     END ELSE
        TestDate = DATE()
     END
     * Run tests
     *
     * Dates
     *
     CRT "Date: ":TestDate
     CRT "D2/ - ":OCONV(TestDate,"D2/")
     CRT "D2- - ":OCONV(TestDate,"D2-")
     CRT "D2  - ":OCONV(TestDate,"D2")
     CRT "D4/ - ":OCONV(TestDate,"D4/")
     CRT "D4- - ":OCONV(TestDate,"D4-")
     CRT "D4  - ":OCONV(TestDate,"D4")
     CRT "DD  - ":OCONV(TestDate,"DD")
     CRT "DW  - ":OCONV(TestDate,"DW")
     CRT "DWA - ":OCONV(TestDate,"DWA")
     CRT "DWB - ":OCONV(TestDate,"DWB")
     CRT "DM  - ":OCONV(TestDate,"DM")
     CRT "DMA - ":OCONV(TestDate,"DMA")
     CRT "DMB - ":OCONV(TestDate,"DMB")
     CRT "DQ  - ":OCONV(TestDate,"DQ")
     CRT "DY  - ":OCONV(TestDate,"DY")
     CRT "DY2 - ":OCONV(TestDate,"D2Y")
     CRT "DY4 - ":OCONV(TestDate,"D4Y")
     *
     * Time
     *
     TestTime = TIME()
     CRT "Time - ":TestTime
     CRT "MT   - ":OCONV(TestTime, "MT")
     CRT "MTS  - ":OCONV(TestTime, "MTS")
     CRT "MTHS - ":OCONV(TestTime, "MTHS")
  END