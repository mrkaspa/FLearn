module Home.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Import.React
open Fable.Helpers.React.Props
open Types

type [<Pojo>] Props =
    { source: string } //other properties here

let ReactMarkdown = importDefault<Props -> ReactElement> "react-markdown"

//create using
let mdview _ _ =
    let props = {
        source = "# This is a header\n\nAnd this is a paragraph"
    }
    fn ReactMarkdown props []

let root model dispatch =
    div []
        [ p [ ClassName "control" ]
            [ input
                [ ClassName "input"
                ; Type "text"
                ; Placeholder "Type your name"; DefaultValue model
                ; AutoFocus true
                ; OnChange (fun ev -> !!ev.target?value |> ChangeStr |> dispatch )
                ]
            ]
        ; br []
        ; span [] [ str (sprintf "Hello %s" model) ]
        ; br []
        ; br []
        ; h1 [ Style [ FontWeight "bolder" ] ] [ str "Markdown" ]
        ; br []
        ; mdview [] []
        ]
