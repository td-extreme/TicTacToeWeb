module TicTacToeWeb.View

let convert (value) =
    match value with
    | "One" -> "X"
    | "Two" -> "O"
    | _ -> "_"

let getPlayerAtSpace (board: Aoxian.TicTacToe.Board, space) = board.TTTBoard.Item(space) |> convert

let moveForm() =
    "<form action=\"/game\">" + "Move:<br>" + "<input type=\"text\" name=\"move\">"
    + "<input type=\"submit\" value=\"Submit\">" + "</form>"

let status (game: Aoxian.TicTacToe.Game) =
    match game.GameStatus() with
    | Aoxian.TicTacToe.Types.GameStatus.InProgress -> moveForm()
    | result -> result.ToString()

let board (game: Aoxian.TicTacToe.Game) =
    let board = (game.Board :?> Aoxian.TicTacToe.Board)
    "<!DOCTYPE html><html><body>" + getPlayerAtSpace (board, 1) + "|" + getPlayerAtSpace (board, 2) + "|"
    + getPlayerAtSpace (board, 3) + "<br>" + getPlayerAtSpace (board, 4) + "|" + getPlayerAtSpace (board, 5) + "|"
    + getPlayerAtSpace (board, 6) + "<br>" + getPlayerAtSpace (board, 7) + "|" + getPlayerAtSpace (board, 8) + "|"
    + getPlayerAtSpace (board, 9) + "<br>" + status (game) + "</body></html>"
