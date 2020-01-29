module TicTacToeWeb.Tests.UtilsTests

open System
open System.IO
open TicTacToeWeb
open Xunit


[<Fact>]
let ``Logging request & response format includes all elements`` () =
    let testRequest = Aoxian.Web.HTTP.Request()
    let testResponse = Aoxian.Web.HTTP.Response()
    let expectedOutput =
       sprintf "Received: %A\nMethod: %s\nHeaders: %A\nBody: %s\nParameters: %A\n\n\
       Result is %A\nStatusCode: %A\nHeaders: %A\nBody: %s\n\n\n"
           testRequest
           testRequest.Method
           testRequest.Headers
           testRequest.Body
           testRequest.Parameters
           testResponse
           testResponse.StatusCode
           testResponse.Headers
           testResponse.Body

    let stringOutput = new StringWriter()
    Console.SetOut(stringOutput)
    Utils.log testRequest testResponse
    Console.Out.Flush()
    let logStatement = stringOutput.GetStringBuilder().ToString()

    Assert.Equal(expectedOutput, logStatement)
