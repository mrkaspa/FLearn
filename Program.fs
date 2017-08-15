module Program

open System
open System.IO
open Demo
open XPrint
open Suave

type Sum = Sum of int

let writeToFile (date: DateTime) filename text =
    let path = sprintf "%s-%O.txt" filename (date.ToString "yyMMdd")
    File.WriteAllText (path, text)    

[<EntryPoint>]
let main argv =
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
    startWebServer defaultConfig (Successful.OK "Hello World!")
    0 // return an integer exit code 