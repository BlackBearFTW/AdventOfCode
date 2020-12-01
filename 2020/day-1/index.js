let fs = require("fs");

fs.readFile("input.txt", (err, content) => {
    const valueArray = content.toString().split('\r\n');
    const sum = 2020;

    for (let i of valueArray) {
        i = Number(i);
        const valueLeft = sum - i;

        if (valueArray.includes(valueLeft.toString())) {
            console.log(`${valueLeft} And ${i} = ${valueLeft + i}`);
            console.log(valueLeft * i);
            break;
        }
    }
});

