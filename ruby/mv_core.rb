# mv_core.rb
# by Aaron Young
# on 09/30/19
# Originally published in Intl-Spectrum.com
# -----------------------------------------
require "Date"

def mv_oconv(value, rule)
  upcased_rule = rule.upcase
  one_letter_rule = upcased_rule[0]
  two_letter_rule = upcased_rule[0..1]
  if one_letter_rule == "D"
    result = mv_oconv_date(value, rule)
  elsif one_letter_rule == "G"
    result = mv_oconv_group(value, rule)
  elsif two_letter_rule == "MT"
    result = mv_oconv_time(value, rule)
  else
    result = nil
  end
  result.to_s
end

def mv_oconv_date(value, rule)
  date = Date.new(1969,1,1) + value

  case rule
  when "DM"
    date.month
  when "DD"
    date.day
  when /D[1234][-\/]/
    get_date(date, rule)
  when /D[1234]Y/
    get_year(date, rule)
  end
end

def mv_oconv_time(value, rule)
  time = Time.at(value)
  time.gmtime # remove utc offsets
  # convert to a string
  if rule == "MTS"
    time.strftime("%H:%M:%S")
  elsif rule == "MTHS"
    time.strftime("%I:%M:%S")
  else
    nil
  end
end

def mv_oconv_group(value, rule)
  actual_rule = rule[1..-1] # remove first char
  delimiter = find_first_non_numeric_value(actual_rule)
  skip_num, take_num = actual_rule.split(delimiter).map(&:to_i)
  array = value.split(delimiter)
  array[skip_num..-1].take(take_num)
end

# helpers

def get_date(date, rule)
  delimiter = rule[2]
  year_length = rule[1]
  year = get_year(date, rule)
  date.strftime("%-m#{delimiter}%-d#{delimiter}") + year
end

def get_year(date, rule)
  start_pos = -1 * rule[1].to_i
  end_pos = -1
  year = date.strftime("%Y")
  year[start_pos..end_pos]
end

def find_first_non_numeric_value(value)
  (0...value.length).each do |pos|
    char = value[pos]
    return char unless is_integer(char)
  end
  nil
end

def is_integer(value)
  begin
    Integer(value)
    true
  rescue
    false
  end
end
