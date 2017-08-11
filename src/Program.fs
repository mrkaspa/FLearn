module Program

open System
open Demo

[<EntryPoint>]
let main argv =
  let numbers = [1; 2; 3]
  printfn "%A" (mapi [])
  printfn "%A" (mapi numbers)
  printfn "sum of: %d" (reduci numbers)
  pcmp EQ
  printf "Ingrese su nombre: "
  let name = Console.ReadLine ()
  printfn "hola mundo %s" name
  0 // return an integer exit code