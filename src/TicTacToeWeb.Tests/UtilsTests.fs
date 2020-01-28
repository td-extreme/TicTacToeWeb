module TicTacToeWeb.Tests.UtilsTests

open System
open System.IO
open TicTacToeWeb
open Xunit

[<Fact>]
let ``readFile retrieves file contents from files in Site folder`` () =
    let contents = Utils.readFile("index.html")
    Assert.True(contents.Length > 1)
    Assert.Contains("Tic Tac Toe", contents)

[<Fact>]
let ``readFile returns emtpy string if a file doesn't exist`` () =
    let contents = Utils.readFile("doesnt_exist.txt")
    Assert.True(contents.Length = 0)
    Assert.Equal("", contents)

[<Fact>]
let ``Logging request & response format includes all elements`` () =
    let testRequest = Aoxian.Web.HTTP.Request()
    let testResponse = Aoxian.Web.HTTP.Response()
    let expectedOutput =
       sprintf "Received: %A\nMethod: %s\nPath: %s\nHeaders: %A\nBody: %s\nParameters: %A\n\n\
       Result is %A\nStatusCode: %A\nHeaders: %A\nBody: %s\n\n\n"
           testRequest
           testRequest.Method
           testRequest.Path
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

[<Theory>]
[<InlineData("file.css", "text/css")>]
[<InlineData("file.html", "text/html")>]
[<InlineData("file.js", "text/javascript")>]
[<InlineData("README.md", "text/plain")>]
[<InlineData("no_extension", "text/plain")>]
let ``contentType returns the approriate content-type value for a given file`` (pathWithFile, expectedResult) =
    let actualResult = Utils.contentType pathWithFile
    Assert.Equal(expectedResult, actualResult)
