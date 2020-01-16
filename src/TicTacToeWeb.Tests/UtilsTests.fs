module TicTacToeWeb.Tests.UtilsTests

open Aoxian.TicTacToe
open TicTacToeWeb
open Xunit

[<Fact>]
let ``readFile retrieves file contents from files in Site folder`` () =
    let contents = Utils.readFile("Game/mock.html")
    Assert.True(contents.Length > 1)
    Assert.Contains("Mock Body", contents)

[<Fact>]
let ``readFile returns emtpy string if a file doesn't exist`` () =
    let contents = Utils.readFile("doesnt_exist.txt")
    Assert.True(contents.Length = 0)
    Assert.Equal("", contents)

[<Fact>]
let ``currentBoardJSON constructs a JSON of the state of a given board`` () =
    let testGame = GameBuilder().Build()
    testGame.ProcessMove(5)
    testGame.NextPlayer()
    testGame.ProcessMove(3)
    let testBoard = (testGame.Board :?> Board).TTTBoard
    let expectedResult = "{ \"tttBoard\": { \"1\": \"\", \"2\": \"\", \"3\": \"Two\", \"4\": \"\", \"5\": \"One\", \"6\": \"\", \"7\": \"\", \"8\": \"\", \"9\": \"\" } }"
    Assert.Equal(expectedResult, Utils.currentBoardJSON testBoard)

[<Theory>]
[<InlineData("style.css", "text/css")>]
[<InlineData("index.html", "text/html")>]
[<InlineData("index.js", "text/javascript")>]
[<InlineData("sample.json", "application/json")>]
[<InlineData("README.md", "text/plain")>]
[<InlineData("no_extension", "text/plain")>]
let ``contentType returns the approriate content-type value for a given file`` (pathWithFile, expectedResult) =
    let actualResult = Utils.contentType pathWithFile
    Assert.Equal(expectedResult, actualResult)
