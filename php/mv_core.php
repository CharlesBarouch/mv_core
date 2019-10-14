<?php
// mv_core.php
// by Charles Barouch (Results@HDWP.com)
// on 09/15/19
// Originally published in Intl-Spectrum.com
// -----------------------------------------
function mv_oconv($value,$rule)
{
    $rule_1 = strtoupper(substr($rule,0,1));
    $rule_2 = substr($rule,0,2);
    if(     $rule_1 == 'D')  { $result = mv_oconv_date($value,$rule);}
    else if($rule_1 == 'G')  { $result = mv_oconv_group($value,$rule);}
    else if($rule_2 == 'MT') { $result = mv_oconv_time($value,$rule);}
    return $result;
}

function mv_oconv_date($value,$rule)
{
    $dt = new DateTime("1967-12-31 00:00:00");
    $dt->Modify('+'.$value.' day');
    $mdy = [$dt->format("m"),$dt->format("d"),$dt->format("Y")];
    $dlmtr = '/';
    if(strpos($rule,'-',1)) {$dlmtr = '-';}
    if(is_numeric(substr($rule,1,1)))
    {
         $mdy[2] = substr($mdy[2],-1*substr($rule,1,1));
    }
    if(strpos($rule,'Y')) {$result = $mdy[2];} else {
        if(substr($rule,0,2) == 'DM') {$result = $mdy[0]; } else {
            if(substr($rule,0,2) == 'DD') {$result = $mdy[1]; } else {
                $result = $mdy[0] . $dlmtr . $mdy[1] . $dlmtr . $mdy[2];
            }
        }
    }
    return $result;
}

function mv_oconv_time($value,$rule)
{
    $hour   = floor($value / 3600);
    $minute = floor(($value - $hour*3600)/ 60);
    $second = $value - ($hour*3600 + $minute*60);
    $apm    = '';
    if (substr($rule,2,1) == 'H')
    {
        $hour = ($hour % 24);
        if($hour >= '00' && $hour <= '11') {$apm = 'am';} else {$apm = 'pm'; $hour = $hour - 12;}
    }
    $hour   = str_pad($hour,   2, "0", STR_PAD_LEFT );
    $minute = str_pad($minute, 2, "0", STR_PAD_LEFT );
    $second = str_pad($second, 2, "0", STR_PAD_LEFT );
    $result = $hour . ':' . $minute . ':' . $second . $apm;
    return $result;
}

function mv_oconv_group($value,$rule)
{
    // Split up the Rule into Skip, Delimiter, and Take
    $skip  = 0;
    $take  = 0;
    $dlmtr = '';
    $rpos  = 0;
    $smax  = strlen($rule);
    for ($scnt = 1; $scnt < $smax; $scnt++)
    {
        $chr = $rule[$scnt];
        if(is_numeric($chr))
        {
            if($rpos == 0){$skip .= $chr;} else {$take .= $chr;}
        } else {
            if($dlmtr == ''){ $dlmtr = $chr; }
            $rpos = 2;
        }
    }
    $result = '';
    $temp = explode($dlmtr,$value);
    $skip += 0; // Force numeric
    $rmax = $skip + $take;
    for($rcnt = $skip; $rcnt < $rmax; $rcnt++)
    {
        if($result != '') { $result .= $dlmtr;}
        $result .= $temp[$rcnt];
    }
    return $result;
}
?>
