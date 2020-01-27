const startGame = () => {
    initBoard();
};

const initBoard = () => {
    for (squareIndex = 1; squareIndex <= 9; squareIndex++) {
        let square = document.createElement("li");
        let squareId = squareIndex.toString();
        square.id = "square-" + squareId;
        square.className = "square";
        let content = document.createTextNode(squareId);
        square.appendChild(content);
        document.getElementById("game-board").appendChild(square);
    }
};