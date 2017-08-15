module Prog.Say

type Salute = {
    Short: string
    Long: string
}

let say salute short =
    if short then
        printfn "%s" salute.Short
    else
        printfn "%s" salute.Long