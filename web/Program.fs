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

let main2 argv =
    let cts = new CancellationTokenSource()
    let conf = { defaultConfig with cancellationToken = cts.Token }
    let listening, server = startWebServerAsync defaultConfig app
    Async.Start(server, cts.Token)
    printfn "Make requests now"
    Console.ReadKey true |> ignore
    cts.Cancel()
    0

open Dapper
open Npgsql
open System.Data

type User() =
    member val FirstName = "" with get, set
    member val Email = "" with get, set

[<EntryPoint>]
let main argv =
    let connString = "Host=localhost;Username=mrkaspa;Password=;Database=subs_dev"
    use conn = new NpgsqlConnection(connString)
    conn.Open()
    let query = "select first_name, email from auth_user"
    let res = conn.Query<User>(query).AsList() |> List.ofSeq
    List.iter (fun (n : User) -> printfn "%s" n.Email) res
    0
