let fs = require("fs");

fs.readFile("input.txt", (err, content) => {
    const valueArray = content.toString().split('\r\n');
    let acceptCount = 0;

    for (let item of valueArray) {

        // split item on space
        const data = item.split(/ +/);

        // split first data item on '-' and get the min and max value
        const minValue = data[0].split('-')[0];
        const maxValue = data[0].split('-')[1];

        // get the character that needs to be seached for and remove ':'
        const matchChar = data[1].slice(0, -1);

        // get the input string
        const matchString = data[2];

        // count occurrences of character in string
        const count = matchString.split(matchChar).length - 1;

        // check if its between the minvalue and maxvalue
        if (count >= minValue && count <= maxValue) {
            acceptCount++;
        }

    }

    console.log(acceptCount);
});