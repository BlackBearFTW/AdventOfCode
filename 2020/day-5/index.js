let fs = require("fs");

fs.readFile("input.txt", (err, content) => {
    const valueArray = content.toString().split('\r\n');
    const boardingPassArray = [];

    // Part 1
    for (let item of valueArray) {
        let minRowPos = 0;
        let maxRowPos = 127;
        let minSeatPos = 0;
        let maxSeatPos = 7;

        for (let char of item) {

            if (char == "F" || char == "B") {

                // Get amount of leftover rows
                let rowCount = (maxRowPos - minRowPos) / 2;

                switch (char) {
                    case 'F':
                        maxRowPos = minRowPos + rowCount;
                        break;
                    case 'B':
                        minRowPos = maxRowPos - rowCount;
                        break;
                }

            } else if (char == "R" || char == "L") {

                let seatCount = (maxSeatPos - minSeatPos) / 2;

                switch (char) {
                    case 'L':
                        maxSeatPos = minSeatPos + seatCount;
                        break;
                    case 'R':
                        minSeatPos = maxSeatPos - seatCount;
                        break;
                }

            }
        }

        boardingPassArray.push((Math.floor(maxRowPos) * 8 + Math.floor(maxSeatPos)));
    }

console.log(Math.max(...boardingPassArray));


    // Part 2
    boardingPassArray.sort(function(a, b) {
        return a - b;
    });

    let count = 85;
   for (let i = 0; i < boardingPassArray.length; i++) {
       if (boardingPassArray[i] !== count) console.log(boardingPassArray[i] +' is not '+ count);
       count++
   }
 // Answer was 853 since it stopped being wrong there

});