module TicTacToeWeb.Utils

open Aoxian.Web.HTTP

let log (request: Request) (response : Response) =
   printfn "Received: %A\nMethod: %s\nHeaders: %A\nBody: %s\nParameters: %A\n"
       request
       request.Method
       request.Headers
       request.Body
       request.Parameters
   printfn "Result is %A\nStatusCode: %A\nHeaders: %A\nBody: %s\n\n"
       response
       response.StatusCode
       response.Headers
       response.Body

let httpLogger anyMethod (request : Request) (withLogging : bool) =
   let (response : Response) = anyMethod request
   if withLogging = true then log request response
   response :> IResponse
