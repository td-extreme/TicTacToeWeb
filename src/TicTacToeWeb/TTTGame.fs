module TicTacToeWeb.TTTGame

open Aoxian.TicTacToe

type TTTGame() = 
    
    member this.TTTBoard(game : Game) =
        Utils.currentBoardJSON (game.Board :?> Board).TTTBoard

    member this.MarkBoard(game : Game, mark : string) =
        game.ProcessMove(mark |> int)