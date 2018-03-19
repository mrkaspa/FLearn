open System

let random = Random()

let pickNumber () = async { return random.Next(10) }

let duration f =
    let timer = DateTime.Now
    f ()
    let now = DateTime.Now
    printfn "Elapsed Time: %d msecs" (now.Subtract(timer).Milliseconds)

let exec () =
    [1..50]
    |> List.map (fun _m -> pickNumber ())
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore

[<EntryPoint>]
let main _argv =
    duration exec
    0 // return an integer exit code
