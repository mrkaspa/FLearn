open System
open Hopac

let random = Random()

let pickNumberAsync () = async { return random.Next(10) }

let pickNumberHopac resCh = job {
    do! Ch.give resCh (random.Next(10))
}

let duration tag f =
    let timer = DateTime.Now
    f ()
    let now = DateTime.Now
    printfn "Elapsed Time in %s: %d msecs" tag (now.Subtract(timer).Milliseconds)

let execAsync () =
    [1..50]
    |> List.map (fun _m -> pickNumberAsync ())
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore

let execHopac () =
    let resCh = Ch<int>()
    [1..50]
    |> List.map (fun _n -> pickNumberHopac resCh)
    |> Job.conIgnore
    |> start

    for _i in [1..50] do
        Ch.take resCh |> ignore

[<EntryPoint>]
let main _argv =
    duration "Async" execAsync
    duration "Hopac" execHopac
    0 // return an integer exit code
