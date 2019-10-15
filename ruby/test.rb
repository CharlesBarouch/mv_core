# test.rb
# by Aaron Young (brainomite@gmail.com)
# on 09/30/19
# -----------------------------------------
require_relative "mv_core.rb"

puts "Loaded Test Cases"
file = File.open(__dir__ + "/../teststack.txt")
# read the file and remove linefeeds
stack_data = file_data = file.read.chomp
tests = stack_data.split("^")
tests.each do |test|
  params = test.split("]")
  value = params[0]
  rule = params[1]
  expected = params[2]
  puts "mv_oconv(#{value}, \"#{rule}\") - Expected: '#{expected}' - Actual: '#{mv_oconv(value, rule)}'"
end
puts ""

# Run some pre-set cases
puts "Hardcoded Cases"
puts mv_oconv(18500,'D2/') # 08/25/18
puts mv_oconv(18500,'D4-') # 08-25-2018
puts mv_oconv(18500,'DM') # 08
puts mv_oconv(18500,'DD') # 25
puts mv_oconv(18500,'D2Y') # 18
puts mv_oconv(86375,'MTS') # 23:59:35
puts mv_oconv(86375,'MTHS') # 11:59:35pm
puts mv_oconv('A!BB!CCC!DDD!DDD','G1!3') # ["BB", "CCC", "DDD"]
