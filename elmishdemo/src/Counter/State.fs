module Counter.State

open Elmish
open Types

let init () : Model * Cmd<Msg> =
    0, []

let update msg model =
    match msg with
    | Increment n ->
      model + n, []
    | Decrement n->
      model - n, []
    | Reset ->
      0, []
