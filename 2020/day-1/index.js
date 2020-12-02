let fs = require("fs");

fs.readFile("input.txt", (err, content) => {
    const valueArray = content.toString().split('\r\n');
    const sum = 2020;

    for (let i of valueArray) {
        i = Number(i);
        const valueLeft = sum - i;

        if (valueArray.includes(valueLeft.toString())) {

            // Part 1
            console.log('Part 1');
            console.log(`${valueLeft} + ${i} = ${valueLeft + i}`);
            console.log(`${valueLeft} * ${i} = ` + valueLeft * i);

            // Part 2
            console.log('\nPart 2');
            console.log('404, Solution not found');

            // End For loop
            break;
        }

    }

});

