// Learn more about F# at http://fsharp.org
open System
open System.Threading
open Suave
open Suave.Filters
open Suave.Operators
open Suave.DotLiquid
open Suave.Json
open System.Runtime.Serialization

type Model =
    { title : string }

[<DataContract>]
type Foo =
    { [<field:DataMember(Name = "foo")>]
      foo : string }

[<DataContract>]
type Bar =
    { [<field:DataMember(Name = "bar")>]
      bar : string }

setTemplatesDir "./templates"

let o = { title = "Hello World" }

let app =
    choose 
        [ GET >=> choose [ path "/" >=> page "my_page.liquid" o ]
          
          POST 
          >=> choose 
                  [ path "/json" 
                    >=> (mapJson (fun (a : Foo) -> { bar = a.foo })) ] ]

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
