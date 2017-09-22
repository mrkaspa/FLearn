// Learn more about F# at http://fsharp.org

open System
open System.Threading
open Suave
open Suave.Filters
open Suave.Operators
open Suave.DotLiquid
open DotLiquid

type Model =
    { title : string }

setTemplatesDir "./templates"

let o =
    { title = "Hello World" }

let app =
    choose
        [ GET >=> choose
            [ path "/" >=> page "my_page.liquid" o ]]

[<EntryPoint>]
let main argv =
    let cts = new CancellationTokenSource()
    let conf = { defaultConfig with cancellationToken = cts.Token }
    let listening, server = startWebServerAsync defaultConfig app
    Async.Start(server, cts.Token)
    printfn "Make requests now"
    Console.ReadKey true |> ignore
    cts.Cancel()
    0
