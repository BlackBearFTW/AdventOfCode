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

            // End For loop
            break;
        }

    }


    // Part 2
    // Turns input into array
    const list = content.toString().split("\n").map((elt) => parseInt(elt, 10))

    let found = false

    // Loop through all the items
    for (const item of list){

        if (found) break

        // look through all items that arent current item
        for (const item2 of list.filter(el => el !== item)){

            if (found) break

            // loop through all items that arent current item or item2
            for (const item3 of list.filter(el => el !== item && el !==item2))

                if (item + item2 + item3 === 2020){

                    console.log('Part 2');
                    console.log(`${item} + ${item2} + ${item3} = 2020`)
                    console.log(`${item} * ${item2} * ${item3} = ` + item*item2*item3)
                    found = true
                    break;
                }

        }
    }





});

