<?php
// add the function to this script
include_once('./mv_core.php');
//
// Load Test Cases
$stack = file_get_contents('../teststack.txt');
$stack = explode('^',$stack);
echo 'Loaded Test Cases'  . "\r\n";
foreach($stack as $testcase)
{
  $testcase = explode(']',$testcase);
  echo mv_oconv($testcase[0],$testcase[1])  . "\r\n";
}
//
// Run some pre-set cases
echo 'Hardcoded Cases'  . "\r\n";
echo mv_oconv(-1200,'D2/')  . "\r\n";
echo mv_oconv(18500,'D2/')  . "\r\n";
echo mv_oconv(18500,'D4-')  . "\r\n";
echo mv_oconv(18500,'DM')  . "\r\n";
echo mv_oconv(18500,'DD')  . "\r\n";
echo mv_oconv(18500,'D2Y')  . "\r\n";
echo mv_oconv(86375,'MTS') . "\r\n";
echo mv_oconv(86375,'MTHS') . "\r\n";
echo mv_oconv('A!BB!CCC!DDD!DDD','G1!3');
?>
