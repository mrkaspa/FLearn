open System

let say () =
    let x = 
        let y = 100
        y - 1
    printfn "%s %d" "DEMO" x

let eq a b = 
    a = b

say ()
printfn "%A" (System.Random () |> (fun r -> r.Next (1, 6)))

[1; 2; 3]
|> List.sumBy ((+) 1)
|> (fun n -> pown n 2)

let re = ResizeArray<int> ()
re.Add (1)
printfn "%A" re

let mutable di = Map.ofList [("bogota", 1); ("cucuta", 2)]
di <- di.Add ("medallo", 3)
printfn "di %A" 


let funci = ((+) 1) >> ((-) 1)
printfn "%d" (funci 10)

type Gb = Gb of int

type Disk = { SizeGb : Gb }

type Computer =
    { Manufacturer : string
      Disks: Disk list }
let myPc =
    { Manufacturer = "Computers Inc."
      Disks =
            [ { SizeGb = Gb 100 }
              { SizeGb = Gb 250 } ] }

Some 1
|> Option.map ((+) 1)
|> Option.get
