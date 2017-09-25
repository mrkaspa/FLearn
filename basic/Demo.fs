module Demo

type Cmp =
    | GT
    | EQ
    | LT

type Listi<'a> = List<'a>

let mapi (ls: Listi<int>) =
    match ls with
    | [] -> [-1]
    | _ -> (List.map (fun x -> x + 1) ls)

let reduci (ls: Listi<int>) =
    ls
    |> mapi
    |> List.sum

let pcmp cmp =
    match cmp with
        | GT -> printfn "Great"
        | EQ -> printfn "Equal"
        | LT -> printfn "Less"

let parseName (name: string) =
    let parts = name.Split(' ')
    let forename = parts.[0]
    let surname = parts.[1]
    (forename, surname)
