# test.rb
require_relative "mv_core.rb"

puts "Loaded Test Cases"
file = File.open("../teststack.txt")
# read the file and remove linefeeds
stack_data = file_data = file.read.chomp
tests = stack_data.split("^")
tests.each do |test|
  params = test.split("]")
  value = params.first.to_i
  rule = params.last
  puts mv_oconv(value, rule)
end
puts ""

# Run some pre-set cases
puts "Hardcoded Cases"
puts mv_oconv(18500,'D2/') # 08/27/19
puts mv_oconv(18500,'D4-') # 08-27-¡2019
puts mv_oconv(18500,'DM') # 08
puts mv_oconv(18500,'DD') # 27
puts mv_oconv(18500,'D2Y') # 19
puts mv_oconv(86375,'MTS') # 23:59:35
puts mv_oconv(86375,'MTHS') # 11:59:35pm
puts mv_oconv('A!BB!CCC!DDD!DDD','G1!3') # ["BB", "CCC", "DDD"]
