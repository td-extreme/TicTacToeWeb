open Aoxian.Web
open Aoxian.Web.HTTP.utils
open Aoxian.TicTacToe
open TicTacToeWeb.GameControllers

[<EntryPoint>]
let main argv =

    let httpRouter = HTTP.Router()
    let game = Aoxian.TicTacToe.GameBuilder().Build()
    let ttt_game_controller = TTTGameController(game)

    httpRouter.AddAllRoutes( "/game", ttt_game_controller)
    httpRouter.AddAllRoutes( "/game?move=1", ttt_game_controller)
    httpRouter.AddAllRoutes( "/game?move=2", ttt_game_controller)
    httpRouter.AddAllRoutes( "/game?move=3", ttt_game_controller)
    httpRouter.AddAllRoutes( "/game?move=4", ttt_game_controller)
    httpRouter.AddAllRoutes( "/game?move=5", ttt_game_controller)
    httpRouter.AddAllRoutes( "/game?move=6", ttt_game_controller)
    httpRouter.AddAllRoutes( "/game?move=7", ttt_game_controller)
    httpRouter.AddAllRoutes( "/game?move=8", ttt_game_controller)
    httpRouter.AddAllRoutes( "/game?move=9", ttt_game_controller)

    HTTP.HttpServer(httpRouter, "0.0.0.0", 5001).Run()
    0
