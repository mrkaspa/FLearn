open System
open Hopac

let random = Random()

let pickNumberAsync () = async { return random.Next(10) }

let pickNumberHopac () = job { return random.Next(10) }

let duration f =
    let timer = DateTime.Now
    f ()
    let now = DateTime.Now
    printfn "Elapsed Time: %d msecs" (now.Subtract(timer).Milliseconds)

let execAsync () =
    [1..50]
    |> List.map (fun _m -> pickNumberAsync ())
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore

let execHopac () =
    [1..50]
    |> List.map (fun _m -> pickNumberHopac ())
    |> Job. // run
    |> ignore

[<EntryPoint>]
let main _argv =
    duration execAsync
    0 // return an integer exit code
