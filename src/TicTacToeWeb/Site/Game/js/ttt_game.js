const player = "X";
const computer = "O";
let gameMessage = "<Message to player goes here>";

const startGame = () => {
    initBoard();
    loadGame();
};

const initBoard = () => {
    for (i = 1; i <= 9; i++) {
        let square = document.createElement("li");
        let squareId = i.toString();
        square.id = "square-" + squareId;
        square.className = "square";
        let content = document.createTextNode(squareId);
        square.appendChild(content);
        document.getElementById("game-board").appendChild(square);
    }
};

const loadGame = () => {
    refreshBoard();
};

const refreshBoard = (tttBoard) => {
    fetch('/TTTGame')
        .then((response) => {
            return response.json();
        }).then((boardJSON) => {
        drawBoard(boardJSON.tttBoard);
    })
};

const drawBoard = (board) => {
    for (i = 1; i <= 9; i++) {
        let squareId = i.toString();
        let square = document.getElementById("square-" + squareId);
        if (board[squareId] !== "") {
            fillSquare(board[squareId], square)
        } else {
            square.onclick = () => markSquarePlayer(square);
        }
    }
};

const fillSquare = (mark, element) => {
    let displayMark = decodeMark(mark);
    element.classList.add("square--" + displayMark.toLowerCase());
    element.innerHTML = displayMark;
};

const decodeMark = (mark) => {
    if (mark === 'One') return player;
    return computer;
};

const markSquarePlayer = (square) => {
    let requestBody = "Mark=" + square.id.substring(square.id.length - 1);
    let request = new Request('/TTTGame', {
        method: "POST",
        headers: {'Content-Type': 'application/x-www-form-urlencoded'},
        body: requestBody
    });
    fetch(request)
        .then((response) => {
            if (response.status === 200) {
                loadGame();
            } else {
                showMessage("Move Not Accepted");
            }
        })
};

const showMessage = (gameMessage) => {
    document.getElementById("message").innerText = gameMessage;
};