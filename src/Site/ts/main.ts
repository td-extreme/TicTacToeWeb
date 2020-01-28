import Game = TicTacToe.Game;

function startGame() {
    this.game = new Game();
    initBoard();
    refreshBoard(this.game.board);
};

function initBoard() {
    for (var squareIndex = 1; squareIndex <= 9; squareIndex++) {
        let square = document.createElement("li");
        let squareId = squareIndex.toString();
        square.id = "square-" + squareId;
        square.className = "square";
        let content = document.createTextNode(squareId);
        square.appendChild(content);
        document.getElementById("game-board").appendChild(square);
    }
};

function refreshBoard(tttBoard) {
    drawBoard(tttBoard);
};

function drawBoard(board) {
    for (var squareIndex = 1; squareIndex <= 9; squareIndex++) {
        let squareId = squareIndex.toString();
        let square = document.getElementById("square-" + squareId);
        if (squareIsMarked(board[squareId])) {
            fillSquare(board[squareId], square)
        } else {
            square.onclick = () => markSquarePlayer(square);
        }
    }
};

function squareIsMarked(squareContents) {
    return (squareContents === this.game.playerOneMark || squareContents === this.game.playerTwoMark);
}

function fillSquare(player, element) {

    let displayMark = this.game.decodeMark(player);
    element.classList.add("square--" + displayMark.toLowerCase());
    element.innerHTML = displayMark;
};

function markSquarePlayer(square) {
    fillSquare("One", square);
    refreshBoard(this.game.board);
};