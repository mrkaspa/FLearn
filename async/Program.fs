open System
open Hopac
open Hopac.Extensions

let random = Random()
let pickNumberAsync() = async { return random.Next(10) }
let pickNumberHopac() = job { return random.Next(10) }

let duration tag f =
    let timer = DateTime.Now
    f()
    let now = DateTime.Now
    printfn "Elapsed Time in %s: %d msecs" tag
        (now.Subtract(timer).Milliseconds)

let execAsync() =
    [ 1..500 ]
    |> List.map (fun _m -> pickNumberAsync())
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore

let execHopac() =
    [ 1..500 ]
    |> List.map (fun _n -> pickNumberHopac())
    |> Job.conCollect
    |> run
    |> ignore

let matrixRun() =
    let n = 1000
    let mat = Array2D.init n n (fun _ _ -> 0)
    let acc = ref 0
    Array2D.iter (fun v -> acc := !acc + v) mat

[<EntryPoint>]
let main _argv =
    duration "Async 0" execAsync
    duration "Hopac 0" execHopac
    duration "Matrix 0" matrixRun
    duration "Async 1" execAsync
    duration "Hopac 1" execHopac
    duration "Matrix 1" matrixRun
    0 // return an integer exit code
