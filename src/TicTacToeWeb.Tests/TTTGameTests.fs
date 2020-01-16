module TicTacToeWeb.Tests.TTTGameTests

open Aoxian.TicTacToe
open TicTacToeWeb.TTTGame
open Xunit

[<Fact>]
let ``TTTBoard gets the current board state as JSON`` () =
    let testGame = GameBuilder().Build()
    let result = TTTGame().TTTBoard(testGame)
    Assert.Contains("tttBoard", result)
 