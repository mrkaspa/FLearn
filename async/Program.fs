// Learn more about F# at http://fsharp.org

open System

let random = Random()

let pickNumber () = async { return random.Next(10) }

let duration f =
    let timer = Diagnostics.Stopwatch()
    timer.Start()
    let returnValue = f ()
    printfn "Elapsed Time: %d" timer.ElapsedMilliseconds
    returnValue

let exec () =
    let workflows = [ for _i in 1..50 -> pickNumber ()]
    let numbers =
        async {
            let! res = Async.Parallel workflows
            return List.ofArray res
        } |> Async.RunSynchronously
    printfn "Numbers = %A" numbers
    ()

[<EntryPoint>]
let main _argv =
    duration exec
    0 // return an integer exit code
