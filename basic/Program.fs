let ls = [
    (1, 1)
    (1, 1)
]

let sumi ls =
    List.fold (fun acc (a, b) -> a + b + acc) 0 ls

[<EntryPoint>]
let main _args =
    printfn "res = %d" (sumi ls)
    1
