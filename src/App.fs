module App

open Fable.React
open Fable.React.Props
open Elmish
open Elmish.React


type Model = 
    {
        Count : int
    }

type Msg =
    | Increment
    | Decrement
    | IncrementBy of int
    | Reset
    

let init () =
    {
        Count = 42
    }

let update msg model : Model =  
    match msg with
    | Increment ->
        { model with Count = model.Count + 1 } 
    | Decrement ->
        { model with Count = model.Count - 1 } 
    | IncrementBy x ->
        { model with Count = model.Count + x } 
    | Reset -> init() 
     
let view model dispatch = 
    div [] 
        [
         button [ OnClick (fun ev -> dispatch Decrement)] [ str "-"]
         h1 [] [ ofInt model.Count]
         button [ OnClick (fun ev -> dispatch Increment)][ str "+"]
         button [ OnClick (fun ev -> dispatch (IncrementBy 5) )][ str "+5"]
         button [ OnClick (fun ev -> dispatch Reset)][ str "Reset"]

        ]

Program.mkSimple   init update view
|> Program.withReactSynchronous "app"
|> Program.run


