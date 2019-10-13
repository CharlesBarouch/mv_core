const mvOconv = (value, rule) => {
  upcasedRule = rule.toUpperCase();
  oneLetterRule = upcasedRule[0];
  twoLetterRule = upcasedRule.substr(0, 2);

  if (oneLetterRule === "D") {
    return mvOconvDate(value, upcasedRule);
  } else if (twoLetterRule == "MT") {
    return mvOconvTime(value, upcasedRule);
  }
  return `${value}, ${rule}`;
};

const mvOconvTime = (value, rule) => {
  const time = new Date(value * 1000); // uses miliseconds
  const seconds = pad(time.getUTCSeconds());
  const minutes = pad(time.getUTCMinutes());
  if (rule === "MTS") {
    const hours = pad(time.getUTCHours());
    return `${hours}:${minutes}:${seconds}`;
  }
  if (rule === "MTHS") {
    let hours;
    const utcHours = time.getUTCHours();
    if (utcHours === 0) {
      hours = 12;
    } else if (utcHours > 12) {
      hours = utcHours - 12;
    } else {
      hours = utcHours;
    }
    const AMorPM = utcHours < 12 ? "AM" : "PM";
    return `${hours}:${minutes}:${seconds}${AMorPM}`;
  }
};

const mvOconvDate = (value, rule) => {
  const mvEpoch = new Date(1969, 0, 1);
  let date = mvEpoch.addDays(value);

  if (/D[1234][-\/]/.test(rule)) {
    // regular expression for a full date with delimiters i.e. "D2-"
    return getDate(date, rule);
  } else if (/D[1234]Y/.test(rule)) {
    // regular expression for year with a length i.e. "D4Y"
    return getYear(date, rule);
  } else if (rule === "DM") {
    return pad(date.getMonth() + 1); // zero based months
  } else if (rule === "DD") {
    return pad(date.getDate());
  } else {
    return "oops";
  }
};

const getYear = (date, rule) => {
  years = date.getFullYear().toString();
  chars = Number.parseInt(rule[1]);
  return years.substring(4 - chars);
};
const getDate = (date, rule) => {
  day = pad(date.getDate());
  month = pad(date.getMonth() + 1); // zero-based months need to add 1
  year = getYear(date, rule);
  delim = rule[2];
  return `${month}${delim}${day}${delim}${year}`;
  // return "yay";
};

// helpers

const pad = number => {
  if (number < 10) {
    return "0" + number;
  }
  return number.toString();
};

Date.prototype.addDays = function(days) {
  // https://stackoverflow.com/questions/563406/add-days-to-javascript-date
  var date = new Date(this.valueOf());
  date.setDate(date.getDate() + days);
  return date;
};

module.exports = {
  mvOconv
};
