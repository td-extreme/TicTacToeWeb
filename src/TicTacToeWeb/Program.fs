open Aoxian.Web
open TicTacToeWeb.GameControllers

[<EntryPoint>]
let main argv =

    let withLogging =
        match argv with
        [|"--no-logging"|] -> false
        | _ -> true

    let httpRouter = HTTP.Router()

    let files =
         [ "/css/style.css"
           "/index.html";
           "/js/tictactoe.js" ]
    let fileController = FileController(withLogging)
    fileController.AddFileRoutes(httpRouter, files)

    HTTP.HttpServer(httpRouter, "0.0.0.0", 5001).Run()
    0 // return an integer exit code
