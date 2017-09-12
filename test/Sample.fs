module Tests

open Expecto
open Demo

[<Tests>]
let tests =
  testList "samples" [
    testCase "Simple test mapi" <| fun _ ->
      let subject = mapi [0]
      Expect.equal subject [1] "I compute, therefore I am."
  ]
