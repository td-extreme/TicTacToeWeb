module TicTacToeWeb.Tests.GameControllersTests

open System.Collections.Generic
open Aoxian.TicTacToe
open Aoxian.Web.HTTP.utils
open TicTacToeWeb.GameControllers
open Xunit

let buildPostRequst path key value =
    let postRequest = Aoxian.Web.HTTP.Request()
    postRequest.Path <- path 
    let parameters = Dictionary<string, string>()
    parameters.Add(key, value)
    postRequest.Parameters <- parameters
    let requestHeaders = Dictionary<string, string>()
    requestHeaders.Add(Aoxian.Web.HTTP.utils.Header.CONTENT_TYPE, Value.HTML_FORM)
    postRequest.Headers <- requestHeaders
    postRequest

[<Fact>]
let ```TTTGame GET returns a TTTBoard`` () =
    let testGame = GameBuilder().Build() 
    let testRequest = Aoxian.Web.HTTP.Request()
    testRequest.Path <- "/TTTGame"
    let testResult = TTTGameController(testGame).Get(testRequest)

    Assert.Contains("tttBoard", testResult.Body)

[<Fact>]
let ``TTTGame Post returns Bad Request with improperly formated form`` () =
    let testGame = GameBuilder().Build()
    let tttGameController = TTTGameController(testGame)
    let testPostRequest = buildPostRequst "/TTTGame" "Marks" "5" 
    let testPostResult = tttGameController.Post(testPostRequest)

    Assert.Equal(StatusCode.BadRequest, testPostResult.StatusCode)

[<Fact>]
let ``TTTGame POST can mark a TTTBoard`` () =
    let testGame = GameBuilder().Build()
    let tttGameController = TTTGameController(testGame)
    let testPostRequest = buildPostRequst "/TTTGame" "Mark" "5" 
    let testPostResult = tttGameController.Post(testPostRequest)

    Assert.Equal(StatusCode.Ok, testPostResult.StatusCode)

    let testGetRequest = Aoxian.Web.HTTP.Request()
    let getResult = tttGameController.Get(testGetRequest)

    Assert.Contains("\"5\": \"One\"", getResult.Body)

[<Fact>]
let ``Site files found in Game folder`` () =
    let testRequest = Aoxian.Web.HTTP.Request()
    testRequest.Path <- "/mock.html"
    let testResult = FileController().Get(testRequest)
    Assert.Contains("Mock Body", testResult.Body)

[<Fact>]    
let ``FileController AddRoutes() enables file paths`` () =
    let testRequest = Aoxian.Web.HTTP.Request() 
    testRequest.Method <- Method.GET
    testRequest.Path <- "/mock.html" 
    let testRouter = Aoxian.Web.HTTP.Router()
    let testController = FileController()
    
    testController.AddFileRoutes(testRouter, ["/mock.html"])

    let actualResponse = testRouter.Route(testRequest)
    
    Assert.Equal(StatusCode.Ok, actualResponse.StatusCode)
