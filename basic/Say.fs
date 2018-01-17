module Prog.Say

type Salute = {
    Short: string
    Long: string
}

let say {Short=short; Long=long} isShort =
    if isShort then
        printfn "%s" short
    else
        printfn "%s" long

type Demo(name : string) =
    member val Name = name
        with get, set
    member val FullName = name
        with get, set
    member this.Show() =
        printf "%s" this.Name
    static member All() =
        "all"

let demo () =
    let d = Demo("eoo")
    d.Name <- "nu"
    d.Show()
    d
