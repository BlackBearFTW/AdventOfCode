let fs = require("fs");

fs.readFile("input.txt", (err, content) => {
    let valueArray = content.toString().split('\r\n\r\n');

    // Part 1
    let count = 0;

    valueArray.forEach((item) => {
        valueArray[valueArray.indexOf(item)] = item.replace(new RegExp(/\r\n/g), '').trim();
    });

    for (let item of valueArray) {
        count += item.toString().replace(new RegExp(/(.)(?=.*\1)/g), "").trim().length;
    }

    console.log(count)

    // Part 2

    // Reset data
    valueArray = content.toString().split('\r\n\r\n');
    count = 0;

    // turn \r\n into space
    valueArray.forEach((item) => {
        valueArray[valueArray.indexOf(item)] = item.replace(new RegExp(/\r\n/g), ' ');
    });


    // loop through each group
    for (let groupAnswer of valueArray) {
        const groupSize = groupAnswer.split(' ').length;

        // get default commonAnswers
        let commonAnswers = groupAnswer.split(' ')[0].split('');

        // If group only contains a single person, add all answers to count
        if (groupSize === 1) {
            count += groupAnswer.length;
            continue;
        }

        // filter for each character in commonAnswer and check if all persons in a group have that answer
       const finalAnswer = commonAnswers.filter((char) => {
            return (groupAnswer.split(char).length - 1) === groupSize;
        });

        count += finalAnswer.length;
    }

    console.log(count);

});