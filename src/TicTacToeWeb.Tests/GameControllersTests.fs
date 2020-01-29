module TicTacToeWeb.Tests.GameControllersTests

open Aoxian.Web.HTTP.utils
open TicTacToeWeb.GameControllers
open Xunit

[<Fact>]
let ``new game dispalys empty board``() =
    let game = Aoxian.TicTacToe.GameBuilder().Build()
    let controller = TTTGameController(game)

    let testRequest = Aoxian.Web.HTTP.Request()
    testRequest.Method <- Method.GET
    testRequest.Path <- "/game"

    let response = controller.Get(testRequest)

    Assert.Contains("_|_|_<br>_|_|_<br>_|_|_", response.Body)

[<Fact>]
let ``plays a move``() =
    let game = Aoxian.TicTacToe.GameBuilder().Build()
    let controller = TTTGameController(game)

    let testRequest = Aoxian.Web.HTTP.Request()
    testRequest.Method <- Method.GET
    testRequest.Path <- "/game?move=3"

    let response = controller.Get(testRequest)

    Assert.DoesNotContain("_|_|_<br>_|_|_<br>_|_|_", response.Body)
    Assert.Contains("|X<br>", response.Body)

[<Fact>]
let ``display player one winner``() =
    let board = Aoxian.TicTacToe.Board()
    let playerOne = Aoxian.TicTacToe.Types.Player.One
    board.Update(playerOne, 1)
    board.Update(playerOne, 2)
    board.Update(playerOne, 3)
    let game = Aoxian.TicTacToe.GameBuilder(board).Build()
    let controller = TTTGameController(game)

    let testRequest = Aoxian.Web.HTTP.Request()
    testRequest.Method <- Method.GET
    testRequest.Path <- "/game"

    let response = controller.Get(testRequest)

    Assert.DoesNotContain("Submit", response.Body)
    Assert.Contains("PlayerOneWins", response.Body)

[<Fact>]
let ``display player two winner``() =
    let board = Aoxian.TicTacToe.Board()
    let playerTwo = Aoxian.TicTacToe.Types.Player.Two
    board.Update(playerTwo, 1)
    board.Update(playerTwo, 2)
    board.Update(playerTwo, 3)
    let game = Aoxian.TicTacToe.GameBuilder(board).Build()
    let controller = TTTGameController(game)

    let testRequest = Aoxian.Web.HTTP.Request()
    testRequest.Method <- Method.GET
    testRequest.Path <- "/game"

    let response = controller.Get(testRequest)

    Assert.DoesNotContain("Submit", response.Body)
    Assert.Contains("PlayerTwoWins", response.Body)
