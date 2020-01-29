module TicTacToeWeb.View

let convert (value) =
    match value with
    | "One" -> "X"
    | "Two" -> "O"
    | _ -> "_"

let getPlayerAtSpace (board: Aoxian.TicTacToe.Board, space) = board.TTTBoard.Item(space) |> convert

let gameBoard (game: Aoxian.TicTacToe.Game) =
    let board = (game.Board :?> Aoxian.TicTacToe.Board)
    getPlayerAtSpace (board, 1) + "|" + getPlayerAtSpace (board, 2) + "|" + getPlayerAtSpace (board, 3) + "<br>"
    + getPlayerAtSpace (board, 4) + "|" + getPlayerAtSpace (board, 5) + "|" + getPlayerAtSpace (board, 6) + "<br>"
    + getPlayerAtSpace (board, 7) + "|" + getPlayerAtSpace (board, 8) + "|" + getPlayerAtSpace (board, 9) + "<br>"

let submitButton() = "<input type=\"submit\" value=\"Submit\">"

let moveOption (move) = "<option value=\"" + move + "\">" + move + "</option>"

let moveOptions (game: Aoxian.TicTacToe.Game) =
    List.ofSeq (game.Board.AvailableMoves())
    |> List.map (fun move -> moveOption (move.ToString()))
    |> List.reduce (fun acc -> (fun move -> acc + move))

let moveSelect (game: Aoxian.TicTacToe.Game) = "<select name=\"move\">" + moveOptions (game) + "</select>"

let form (game: Aoxian.TicTacToe.Game) =
    match game.GameStatus() with
    | Aoxian.TicTacToe.Types.GameStatus.InProgress ->
        "<form action \"game\">" + moveSelect (game) + submitButton() + "</form>"
    | _ -> ""

let status (game: Aoxian.TicTacToe.Game) =
    match game.GameStatus() with
    | Aoxian.TicTacToe.Types.GameStatus.InProgress -> "<br>"
    | result -> "<br>" + result.ToString() + "<br>"

let showGame (game: Aoxian.TicTacToe.Game) =
    let board = (game.Board :?> Aoxian.TicTacToe.Board)
    "<!DOCTYPE html><html><body>" + gameBoard (game) + form (game) + status (game) + "</body></html>"
