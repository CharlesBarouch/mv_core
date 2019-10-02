import datetime
# mv_core.py
# by Charles Barouch
# on 09/15/19
# Originally published in Intl-Spectrum.com
# -----------------------------------------

def oconv_date(value, rule):
    baseline = datetime.date(1969, 1, 1)
    result = baseline + datetime.timedelta(days=value)
    # Digits in a year
    YearStart  = 0
    YearFinish = 4
    if("2" in rule):
        YearStart  = 2
        YearFinish = 4
    delimiter = '/'
    if("-" in rule):
        delimiter = "-"
    if("Y" in rule):
        result = str(result.year)[YearStart:YearFinish]
    else:
        if("DM" in rule):
            result = str(result.month)
        else:
          if("DD" in rule):
            result = str(result.day)
          else:
            result = str(result.month) + delimiter + str(result.day) + delimiter + (str(result.year)[YearStart:YearFinish])
    return result

def oconv_time(value,rule):
  result = datetime.timedelta(seconds=value)
  return str(result)

def oconv_group(value,rule):
  # split rule into skip, delimiter, and take
  skip = 1
  take = 3
  delimiter = '!'
  # apply rule
  result = ''
  value = value.split(delimiter)
  for parts in value:
      if skip > 0:
          skip -= 1
      else: 
        if take > 0:
            take -= 1
            if result != '':
                result += delimiter
            result += parts
  return result

def oconv(value, rule):
  rule = rule.upper()
  if rule[0] == 'D':
    result = oconv_date(value,rule)
  if rule[0] == 'G':
    result = oconv_group(value,rule)
  if rule[0:2] == 'MT':
    result = oconv_time(value,rule)
  return result