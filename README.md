# mv_core
MV functions in other languages

The goal is to take familiar MV functions and make them available in other languages for two reasons:
1) They are useful.
2) Reading them will help people move from one language to another. Sort of a Rosetta Stone for PHP/PYTHON/RUBY/C#/NodeJS.

Current examples:

mv_oconv(18500,'D2/') [Results:  08/25/18]

mv_oconv(18500,'D4-') [Results:  08-25-2018]

mv_oconv(18500,'DM')  [Results:  08]

mv_oconv(18500,'DD')  [Results:  25]

mv_oconv(18500,'D2Y') [Results:  18]

mv_oconv(86375,'MTS') [Results: 23:59:35]

mv_oconv(86375,'MTHS')[Results: 11:59:35pm]

Each folder has a test program and a function program.
