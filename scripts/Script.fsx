let say () =
    let x = 
        let y = 100
        y - 1
    printfn "%s %d" "DEMO" x

let eq a b = 
    a = b

say ()
printfn "%A" (System.Random () |> (fun r -> r.Next (1, 6)))