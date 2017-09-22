module Db

open Dapper
open Npgsql
open System.Data

type User() =
    member val FirstName = "" with get, set
    member val Email = "" with get, set

let run =
    let connString = "Host=localhost;Username=mrkaspa;Password=;Database=subs_dev"
    use conn = new NpgsqlConnection(connString)
    conn.Open()
    let query = "select first_name, email from auth_user"
    let res = conn.Query<User>(query).AsList() |> List.ofSeq
    List.iter (fun (n : User) -> printfn "%s" n.Email) res
    0
