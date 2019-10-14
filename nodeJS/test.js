// by Aaron Young (brainomite@gmail.com)
// on 09/30/19
// -----------------------------------------
const { mvOconv } = require("./mvCore");
const path = require("path");

const filePath = path.join(__dirname, "..", "teststack.txt");
console.log("Loaded Test Cases");
const stackData = require("fs")
  .readFileSync(filePath, "utf-8")
  .split("\n")
  .filter(Boolean)[0]; // get first line sans new line chars
tests = stackData.split("^");
for (test of tests) {
  const [value, rule, expected] = test.split("]");
  const result = mvOconv(Number.parseInt(value), rule);
  console.log(
    `mv_oconv(${value}, "${rule}") - Expected: '${expected}' - Actual: '${result}'`
  );
}

console.log("");
console.log("Hardcoded Cases");
console.log(mvOconv(18500, "D2/")); // 08/27/19
console.log(mvOconv(18500, "D4-")); // 08-27-2019
console.log(mvOconv(18500, "DM")); // 08
console.log(mvOconv(18500, "DD")); // 27
console.log(mvOconv(18500, "D2Y")); // 19
console.log(mvOconv(86375, "MTS")); // 23:59:35
console.log(mvOconv(86375, "MTHS")); // 11:59:35PM
console.log(mvOconv("A!BB!CCC!DDD!DDD", "G1!3")); // BB,CCC,DDD
