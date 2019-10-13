const { mvOconv } = require("./mv_core");

console.log("Hardcoded Cases");
console.log(mvOconv(18500, "D2/")); // 08/27/19
console.log(mvOconv(18500, "D4-")); // 08-27-2019
console.log(mvOconv(18500, "DM")); // 08
console.log(mvOconv(18500, "DD")); // 27
console.log(mvOconv(18500, "D2Y")); // 19
console.log(mvOconv(86375, "MTS")); // 23:59:35
console.log(mvOconv(86375, "MTHS")); // 11:59:35PM
console.log(mvOconv("A!BB!CCC!DDD!DDD", "G1!3")); // BB,CCC,DDD
