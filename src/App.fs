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

let init () = 
    {
     Count = 42
    }, Cmd.none

let update msg model : Model * Cmd<Msg> =  
    match msg with
    | Increment ->
        { model with Count = model.Count + 1 } , Cmd.none
    | Decrement ->
        { model with Count = model.Count - 1 } , Cmd.none
   
     
let view model dispatch = 
    div [] 
        [
         button [ OnClick (fun ev -> dispatch Decrement)] [ str "-"]
         h1 [] [ ofInt model.Count]
         button [ OnClick (fun ev -> dispatch Increment)][ str "+"]
        ]

Program.mkProgram init update view
|> Program.withReactSynchronous "app"
|> Program.run


