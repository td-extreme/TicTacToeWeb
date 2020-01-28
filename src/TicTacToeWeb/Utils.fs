module TicTacToeWeb.Utils

open Aoxian.Web.HTTP
open System.IO

let readFile(path) =
   let siteFolder = @"../../../../Site/"

   try 
        siteFolder + path
        |> File.ReadAllLines
        |> Seq.toList
        |> Seq.fold (+) ""
   with
        | _ -> ""

let contentType(path : string) =
       try 
            match path.Split('.').[1] with
            | "css" -> "text/css"
            | "html" -> "text/html"
            | "js" -> "text/javascript"
            | _ -> "text/plain"
       with
            | _ -> "text/plain"

let log (request: Request) (response : Response) =
   printfn "Received: %A\nMethod: %s\nPath: %s\nHeaders: %A\nBody: %s\nParameters: %A\n"
       request
       request.Method
       request.Path
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
