module TicTacToeWeb.GameControllers

open Aoxian.Web.HTTP
open Aoxian.Web.HTTP.utils
open TicTacToeWeb.TTTGame

type TTTGameController(game) =
    inherit Controller()
    
    override this.Get(_) =
       ResponseBuilder()
            .AddStatusCode(StatusCode.Ok)
            .AddBody(TTTGame().TTTBoard(game))
            .AddHeader(Header.CONTENT_TYPE, "application/json")
            .Build ()
            :> IResponse
    
    override this.Post(request) =
        try
            let mark = request.Parameters.["Mark"]
            TTTGame().MarkBoard(game, mark)
            ResponseBuilder().AddStatusCode(StatusCode.Ok).Build() :> IResponse
        with
        | _ ->
            ResponseBuilder().AddStatusCode(StatusCode.BadRequest).Build() :> IResponse

type FileController() =
    inherit Controller()
    let viewFolder = "Game"
 
    member this.AddFileRoutes(router: Router, paths) =
        let methods = [|Method.GET; Method.HEAD; Method.OPTIONS|]
        paths
        |> List.map (fun path -> router.AddRoutes(methods, path, this))
        |> ignore

    override this.Get (request) =
       let filePath = viewFolder + request.Path
       ResponseBuilder()
            .AddStatusCode(StatusCode.Ok)
            .AddBody(Utils.readFile(filePath))
            .AddHeader(Header.CONTENT_TYPE, Utils.contentType(request.Path))
            .Build ()
            :> IResponse
