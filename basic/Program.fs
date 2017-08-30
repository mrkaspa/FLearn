module Program

open System
open System.IO
open Demo
open XPrint

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

type User(name : String, age : int) =
    member this.Name = name
    member this.Age = age

[<EntryPoint>]
let main args =
    let u = User("Michel", 30)
    printfn "The user %s has %d yo" u.Name u.Age
    0
