# mv_core.rb
# by Aaron Young (brainomite@gmail.com)
# on 09/30/19
# -----------------------------------------

require "Date"

def mv_oconv(value, rule)
  upcased_rule = rule.upcase # ensure rule is uppercase
  one_letter_rule = upcased_rule[0]
  two_letter_rule = upcased_rule[0..1] # get the first two letters using a range
  if one_letter_rule == "D" # its a date
    result = mv_oconv_date(value.to_i, upcased_rule)
  elsif one_letter_rule == "G" # its a group
    result = mv_oconv_group(value, upcased_rule)
  elsif two_letter_rule == "MT" # its a time
    result = mv_oconv_time(value.to_i, upcased_rule)
  else
    result = nil
  end
  result.to_s
end

def mv_oconv_date(value, rule)
  # create a date starting from 12/31/1967 and add value (days) to it
  date = Date.new(1967,12,31) + value

  case rule
  when "DM"
    date.strftime("%m") # zero padded month string
  when "DD"
    date.strftime("%d") # zero padded day string

  # regular expression for a full date with delimiters i.e. "D2-"
  when /D[1234][-\/]/
    get_date(date, rule)

  # regular expression for year with a length i.e. "D4Y"
  when /D[1234]Y/
    get_year(date, rule)
  end
end

def mv_oconv_time(value, rule)
  time = Time.at(value) # create a time object using seconds
  time.gmtime # remove utc offsets so it isn't skewed
  # convert to a string
  if rule == "MTS" # use military time
    time.strftime("%H:%M:%S")
  elsif rule == "MTHS" # use non-military time with a meridiem indicator
    time.strftime("%I:%M:%S%^P")
  else
    nil # return nothing, not a valid rule
  end
end

def mv_oconv_group(value, rule)
  actual_rule = rule[1..-1] # remove first char
  delimiter = find_first_non_numeric_value(actual_rule) # find the delimiter

  # take the rule and turn into an array using the delimiter then
  # convert all elements into integers and assign the first
  # value to skip_num and second value to take_num
  skip_num, take_num = actual_rule.split(delimiter).map(&:to_i)
  array = value.split(delimiter) # create an array using the delimiter

  # create a sub array by skipping skip_num numbers then take the first
  # take_num elements and return the new resulting array
  array[skip_num..-1].take(take_num)
end

# helpers

def get_date(date, rule)
  delimiter = rule[2]
  year = get_year(date, rule)
  date.strftime("%m#{delimiter}%d#{delimiter}") + year
end

def get_year(date, rule)
  # negative digits is digits from the end of string
  start_pos = -1 * rule[1].to_i
  end_pos = -1 # last char of string
  year = date.strftime("%Y") # get 4 digit string representation of year
  year[start_pos..end_pos] # return substring
end

def find_first_non_numeric_value(value)
  # itterate through the string assigning the current character to char
  value.each_char do |char|
    return char unless is_integer(char) # return the first non integer char
  end
  nil # no non-numeric value was located return nil
end

def is_integer(value)
  begin # start error catching block
    Integer(value) # attempt to convert value to an integer
    true # if it was succesful, return true
  rescue # begin code block that runs after an error
    false # return false, the Integer function errored out
  end
end
