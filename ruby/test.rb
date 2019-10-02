# test.rb
#require_relative "mv_core.rb"

puts mv_oconv(18500,'D2/') # 8/27/19
puts mv_oconv(18500,'D4-') # 8-27-2019
puts mv_oconv(18500,'DM') # 8
puts mv_oconv(18500,'DD') # 27
puts mv_oconv(18500,'D2Y') # 19
puts mv_oconv(86375,'MTS') # 23:59:35
puts mv_oconv(86375,'MTHS') # 11:59:35
puts mv_oconv('A!BB!CCC!DDD!DDD','G1!3') # ["BB", "CCC", "DDD"]
