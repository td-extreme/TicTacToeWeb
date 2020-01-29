import { Game } from './game';

const game = new Game();
const firstSquareOnBoard = 1;
const numberOfSquaresOnBoard = 9;

const startGame = () => {
    initBoard();
    refreshBoard(game.board);
};

const initBoard = () => {
    for (var squareIndex = firstSquareOnBoard; squareIndex <= numberOfSquaresOnBoard; squareIndex++) {
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
    for (var squareIndex = firstSquareOnBoard; squareIndex <= numberOfSquaresOnBoard; squareIndex++) {
        let squareId = squareIndex.toString();
        let square = document.getElementById("square-" + squareId);
        if (squareIsMarked(board[squareId])) {
            fillSquare(board[squareId], square)
        } else {
            square.onclick = () => markSquarePlayer(square);
        }
    }
};

const squareIsMarked = (squareContents) => {
    return (squareContents === game.playerOneMark || squareContents === game.playerTwoMark);
}

const fillSquare = (player, element) => {

    let displayMark = game.decodeMark(player);
    element.classList.add("square--" + displayMark.toLowerCase());
    element.innerHTML = displayMark;
};

const markSquarePlayer = (square) => {
    fillSquare("One", square);
    refreshBoard(game.board);
};

startGame();