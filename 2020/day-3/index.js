let fs = require("fs");

fs.readFile("input.txt", (err, content) => {
    const valueArray = content.toString().split('\r\n');
    const mapLength = valueArray[0].length;
    const mapHeight = valueArray.length;
    let currentX = 0;
    let currentY = 0;
    let treeCount = 0;

    while(currentY + 1 < mapHeight ) {

        currentY += 1;
        currentX += 3;

        if (currentX >= mapLength) {
            currentX -= mapLength;
        }

        if(valueArray[currentY].toString().charAt(currentX) == '#') {
            treeCount++;
        }

    }

    console.log(treeCount);

    // Just used different numbers for part 2 by manually changing them

});