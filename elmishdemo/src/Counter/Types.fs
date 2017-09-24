module Counter.Types

type Model = int

type Msg =
    | Increment of int
    | Decrement of int
    | Reset
