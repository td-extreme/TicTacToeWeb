open Aoxian.Web
open Aoxian.Web.HTTP
open Aoxian.Web.HTTP.utils
open System

type TestController() =
    inherit HTTP.Controller()
    override this.Get (_) =
        ResponseBuilder()
            .AddStatusCode(StatusCode.Ok)
            .AddBody("This Sever brought to you by F#")
            .Build ()
            :> IResponse

[<EntryPoint>]
let main argv =
    let path = "/test_get"
    let testController = TestController
    let testRouter = HTTP.Router()
    testRouter.AddRoute(Method.GET, path, testController())
    let httpServer = HTTP.HttpServer(testRouter, "0.0.0.0", 5001)
    httpServer.Run()
    0 // return an integer exit code
