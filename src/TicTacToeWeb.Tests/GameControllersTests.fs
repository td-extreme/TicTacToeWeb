module TicTacToeWeb.Tests.GameControllersTests

open Aoxian.Web.HTTP.utils
open TicTacToeWeb.GameControllers
open Xunit

let loggingFlag = false

[<Fact>]
let ``Website files found in Site folder`` () =
    let testRequest = Aoxian.Web.HTTP.Request()
    testRequest.Path <- "/index.html"
    let testResult = FileController(loggingFlag).Get(testRequest)
    Assert.Contains("Tic Tac Toe", testResult.Body)

[<Fact>]    
let ``FileController AddRoutes() enables file paths`` () =
    let testRequest = Aoxian.Web.HTTP.Request() 
    testRequest.Method <- Method.GET
    testRequest.Path <- "/index.html" 
    let testRouter = Aoxian.Web.HTTP.Router()
    let testController = FileController(loggingFlag)
    
    testController.AddFileRoutes(testRouter, ["/index.html"])

    let actualResponse = testRouter.Route(testRequest)
    
    Assert.Equal(StatusCode.Ok, actualResponse.StatusCode)
