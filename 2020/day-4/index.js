let fs = require("fs");

fs.readFile("input.txt", (err, content) => {
    const valueArray = content.toString().split('\r\n\r\n');

    valueArray.forEach((item) => {
       valueArray[valueArray.indexOf(item)] = item.replace(new RegExp(/\r\n/g), ' ');
    });
    

    // Part 1
    let validPassports = valueArray.filter((passport) => {

        const requiredFields = ['byr', 'iyr', 'eyr', 'hgt', 'hcl', 'ecl', 'pid'];
        let verify = true;

        for (let field of requiredFields) {
            if (!passport.includes(field)) {
                verify = false;
                break;
            }
        }

        return verify;
    });
    console.log("Part 1");
    console.log(validPassports.length);





    // Part 2
    let fullyValidPassport = validPassports.filter((passport) => {

        let verify = true;
        const fields = passport.split(/ +/);


        for(let field of fields) {
          if (verify == false) break;

            let [key, value] = field.split(':');

            switch (key) {
                case 'byr':
                    if (value.length < 4) {verify = false;};
                    verify = isBetween(Number(value), 1920, 2002);
                    break;

                case 'iyr':
                    if (value.length < 4) {verify = false;};
                    verify = isBetween(Number(value), 2010, 2020);
                    break;

                case 'eyr':
                    if (value.length < 4) {verify = false;};
                    verify = isBetween(Number(value), 2020, 2030);
                    break;

                case 'hgt':
                    if (!value.endsWith('cm') && !value.endsWith('in')) {verify = false; break};
                    if(value.endsWith('cm')) verify = isBetween(Number(value.replace('cm', '')), 150, 193);
                    if(value.endsWith('in')) verify = isBetween(Number(value.replace('in', '')), 59, 76);
                    break;

                case 'hcl':
                    verify = value.match(/#[0-9a-f]{6}/g) || false;
                    break;

                case 'ecl':
                    verify = value.match(/amb|blu|brn|gry|grn|hzl|oth/g) || false;
                    break;

                case 'pid':
                    verify = (value.match(/[0-9]/g).length == 9) || false;
                    break;
            }

        }

        return verify;
    });

    console.log("Part 2");
    console.log(fullyValidPassport.length);

});

function isBetween(n, a, b) {
    return (n - a) * (n - b) <= 0
}