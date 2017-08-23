module XPrint

open Prog.Say

let standard = 
    { Short = "oli"
      Long = "hola" }

let printHello () = 
    let salute = { standard with Short = "OLA KE ASE"}
    say salute true