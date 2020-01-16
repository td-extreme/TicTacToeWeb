module TicTacToeWeb.Utils

open System.IO

let readFile(path) =
   let siteFolder = @"../../../Site/"
  
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
            | "json" -> "application/json"
            | _ -> "text/plain"
       with
            | _ -> "text/plain"

let currentBoardJSON board =
    let mutable boardString = ""
    for KeyValue(key,value) in board do
        boardString <- boardString + (sprintf "\"%d\": \"%s\", " key value)
    boardString <- boardString.Remove((boardString.Length - 2), 2)
    sprintf "{ \"tttBoard\": { %s } }" boardString

 