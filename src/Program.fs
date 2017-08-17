module Program

open System
open System.Threading
open System.IO
open Demo
open XPrint
open Suave
open Suave.Filters
open Suave.Operators
open Suave.DotLiquid
open DotLiquid

type Sum = Sum of int

let writeToFile (date: DateTime) filename text =
    let path = sprintf "%s-%O.txt" filename (date.ToString("yyMMdd"))
    File.WriteAllText(path, text)

let main1 argv =
    writeToFile DateTime.UtcNow.Date "log" "hola desde archivo"
    printfn "%A" argv
    let sumin = Sum 1
    printfn "S %A" sumin
    let numbers = [1; 2; 3]
    printfn "%A" (mapi [])
    printfn "%A" (mapi numbers)
    printfn "sum of: %d" (reduci numbers)
    pcmp EQ
    printf "Ingrese su nombre: "
    let name = Console.ReadLine ()
    printfn "hola mundo %s" name
    printHello ()
    0 // return an integer exit code 

type Model =
  { title : string }

setTemplatesDir "./../templates"

let o = { title = "Hello World" }

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