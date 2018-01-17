// Learn more about F# at http://fsharp.org

open System

let random = Random()

let pickNumber = async { return random.Next(10) }

[<EntryPoint>]
let main _argv =
    let workflows = [ for _i in 1..50 -> pickNumber ]
    let numbers =
        async {
            let! res = Async.Parallel workflows
            return List.ofArray res
        } |> Async.RunSynchronously
    printfn "Numbers = %A" numbers
    0 // return an integer exit code
