module Program

open System
open Demo
open XPrint
open Suave

type Sum = Sum of int

[<EntryPoint>]

let main argv =
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
  startWebServer defaultConfig (Successful.OK "Hello World!")
  0 // return an integer exit code 