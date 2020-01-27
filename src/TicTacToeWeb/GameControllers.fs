module TicTacToeWeb.GameControllers

open Aoxian.Web.HTTP
open Aoxian.Web.HTTP.utils
open TicTacToeWeb

type FileController(withLogging : bool) =
    inherit Controller()

    let get (request : Request) =
       ResponseBuilder()
            .AddStatusCode(StatusCode.Ok)
            .AddBody(Utils.readFile(request.Path))
            .AddHeader(Header.CONTENT_TYPE, Utils.contentType(request.Path))
            .Build ()

    let getWithLogging (request : Request) =
        Utils.httpLogger get request withLogging

    override this.Get (request : IRequest) =
        getWithLogging (request :?> Request)

    member this.AddFileRoutes(router: Router, paths) =
        let methods = [|Method.GET; Method.HEAD; Method.OPTIONS|]
        paths
        |> List.map (fun path -> router.AddRoutes(methods, path, this))
        |> ignore
