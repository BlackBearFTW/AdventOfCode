let fs = require("fs");

fs.readFile("input.txt", (err, content) => {
    const valueArray = content.toString().split('\r\n');
    let acceptCount = 0;

    // Part 1
    for (let item of valueArray) {

        // split item on space
        const data = item.split(/ +/);

        // split first data item on '-' and get the min and max value
        const minValue = data[0].split('-')[0];
        const maxValue = data[0].split('-')[1];

        // get the character that needs to be searched for and remove ':'
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

    console.log('Part 1');
    console.log(acceptCount);


    // Part 2
    let matchCount = 0;

    for (let item of valueArray) {

        // split item on space
        const data = item.split(/ +/);

        // split first data item on '-' and get the first and second index (-1 since there is no 0 index in input)
        const firstIndex = Number(data[0].split('-')[0]) - 1;
        const secondIndex = Number(data[0].split('-')[1]) - 1;

        // get the character that needs to be searched for and remove ':'
        const matchChar = data[1].slice(0, -1);

        // get the input string
        const matchString = data[2];

        if (matchString.charAt(firstIndex) == matchChar && matchString.charAt(secondIndex) !== matchChar) {
            matchCount++;
        } else if (matchString.charAt(firstIndex) !== matchChar && matchString.charAt(secondIndex) == matchChar) {
            matchCount++;
        }

    }

    console.log('Part 2');
    console.log(matchCount);

});
