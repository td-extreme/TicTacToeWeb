const playerName = "One";
const playerMark = "X";
const computerName = "Two";
const computerMark = "O";

let board = {
    'tttBoard': {
        '1': '',
        '2': '',
        '3': '',
        '4': '',
        '5': '',
        '6': '',
        '7': '',
        '8': '',
        '9': ''
    }
};

const startGame = () => {
    initBoard();
    refreshBoard(board);
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

const refreshBoard = (tttBoard) => {
    drawBoard(tttBoard);
};

const drawBoard = (board) => {
    for (i = 1; i <= 9; i++) {
        let squareId = i.toString();
        let square = document.getElementById("square-" + squareId);
        if (board[squareId] === playerName || board[squareId] === computerName) {
            fillSquare(board[squareId], square)
        } else {
            square.onclick = () => markSquarePlayer(square);
        }
    }
};

const fillSquare = (player, element) => {
    let displayMark = decodeMark(player);
    element.classList.add("square--" + displayMark.toLowerCase());
    element.innerHTML = displayMark;
};

const decodeMark = (player) => {
    if (player === playerName) return playerMark;
    return computerMark;
};

const markSquarePlayer = (square) => {
    fillSquare(playerName, square);
    refreshBoard(board);
};