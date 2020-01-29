module TicTacToeWeb.GameControllers

open Aoxian.Web.HTTP
open Aoxian.Web.HTTP.utils
open TicTacToeWeb

type TTTGameController(tttGame: Aoxian.TicTacToe.Game) =
    inherit Controller()

    let playPcMove() =
        if tttGame.GameStatus() = Aoxian.TicTacToe.Types.GameStatus.InProgress then
            tttGame.NextPlayer()
            tttGame.ProcessMove(tttGame.GameAi.GetMove(tttGame.Board))
            tttGame.NextPlayer()

    let playMove (request: Request) =
        let move = int request.Path.[request.Path.Length - 1] - 48
        if 1 <= move && move <= 9 then
            tttGame.ProcessMove(move)
            playPcMove()

    let get (request: Request) =
        playMove (request)
        ResponseBuilder().AddStatusCode(StatusCode.Ok).AddBody(TicTacToeWeb.View.board (tttGame)).Build()

    let getWithLogging (request: Request) = Utils.httpLogger get request true

    override this.Get(request: IRequest) = getWithLogging (request :?> Request)
