open Aoxian.TicTacToe
open Aoxian.Web
open Aoxian.Web.HTTP.utils
open TicTacToeWeb.GameControllers

[<EntryPoint>]
let main argv =
    let httpRouter = HTTP.Router()
    
    let mutable game = GameBuilder().Build()   
    httpRouter.AddRoutes([|Method.GET; Method.HEAD; Method.POST; Method.OPTIONS|], "/TTTGame", TTTGameController(game))

    let files =
         [ "/css/style.css"
           "/index.html";
           "/js/ttt_game.js" ]
    let fileController = FileController()
    fileController.AddFileRoutes(httpRouter, files)
    
    HTTP.HttpServer(httpRouter, "0.0.0.0", 5001).Run()
    0 // return an integer exit code
