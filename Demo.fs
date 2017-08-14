module Demo

type Cmp =
    | GT
    | EQ
    | LT

type 'a Listi = 'a List
 
let mapi (ls : int Listi) =
  match ls with
    | [] -> [-1]
    | _ -> (List.map (fun x -> x + 1) ls)

let reduci (ls : int Listi) =
  ls
  |> mapi
  |> List.sum

let pcmp cmp =
  match cmp with
    | GT -> printfn "Great"
    | EQ -> printfn "Equal"
    | LT -> printfn "Less"