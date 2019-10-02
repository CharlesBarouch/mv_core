<?php
include_once('./mv_core.php');
$stack = file_get_contents('../teststack.tt');
$stack = explode('^',$stack);
foreach($stack as $testcase)
{
  $testcase = explode(']',$testcase);
  echo mv_oconv($testcase[0],$testcase[1])  . "\r\n";
}
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
