namespace TicTacToe {
    export class Game {
        board: { "tttBoard": { "1": string, "2": string, "3": string, "4": string, "5": string, "6": string, "7": string, "8": string, "9": string } }
        playerOne = "One";
        playerTwo = "Two";
        playerOneMark = "X";
        playerTwoMark = "O";

        constructor() {
            this.board = {
                "tttBoard": {
                    "1": "",
                    "2": "",
                    "3": "",
                    "4": "",
                    "5": "",
                    "6": "",
                    "7": "",
                    "8": "",
                    "9": ""
                }
            };
        }

        decodeMark(playerName) {
            if (playerName === this.playerOne) return this.playerOneMark;
            return this.playerTwoMark;
        };
    }
}