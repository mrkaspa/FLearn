open System
open Hopac

let random = Random()

let pickNumberAsync () = async { return random.Next(10) }

let pickNumberHopac () = job {
    return random.Next(10)
}

let duration tag f =
    let timer = DateTime.Now
    f ()
    let now = DateTime.Now
    printfn "Elapsed Time in %s: %d msecs" tag (now.Subtract(timer).Milliseconds)

let execAsync () =
    [1..500]
    |> List.map (fun _m -> pickNumberAsync ())
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore

let execHopac () =
    [1..500]
    |> List.map (fun _n -> pickNumberHopac ())
    |> Job.conCollect
    |> run
    |> ignore

[<EntryPoint>]
let main _argv =
    duration "Async" execAsync
    duration "Hopac" execHopac
    0 // return an integer exit code
