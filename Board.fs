module Board

// Type alias for the Sudoku board (9x9 2D array)
type Board = int[,]

// Create an empty 9x9 board
let createEmpty () : Board =
    Array2D.create 9 9 0

// Get cell value at position (row, col)
let getCell (board: Board) row col : int =
    board.[row, col]

// Set cell value - returns NEW board (immutable)
let setCell (board: Board) row col value : Board =
    let newBoard = Array2D.copy board
    newBoard.[row, col] <- value
    newBoard

// Check if cell is empty
let isEmpty (board: Board) row col : bool =
    board.[row, col] = 0

// Extract row as list
let getRow (board: Board) row : int list =
    [ for col in 0..8 -> board.[row, col] ]

// Extract column as list
let getCol (board: Board) col : int list =
    [ for row in 0..8 -> board.[row, col] ]

// Extract a 3×3 box
let getBox (board: Board) row col : int list =
    let boxRow = (row / 3) * 3
    let boxCol = (col / 3) * 3
    [ for r in boxRow..boxRow+2 do
        for c in boxCol..boxCol+2 -> board.[r, c] ]

// Load board from 9 lines of 9 space-separated values
let loadFromFile (filename: string) : Board option =
    try
        let lines =
            System.IO.File.ReadAllLines(filename)
            |> Array.filter (fun l -> l.Trim().Length > 0)

        if lines.Length <> 9 then
            None
        else
            let board = createEmpty()

            for row in 0..8 do
                let values =
                    lines.[row].Split([|' '|], System.StringSplitOptions.RemoveEmptyEntries)

                if values.Length <> 9 then
                    failwith $"Line {row+1} does not have 9 values."

                for col in 0..8 do
                    board.[row, col] <- int values.[col]

            Some board

    with ex ->
        printfn "Error loading file: %s" ex.Message
        None

// Print board formatted (with boxes)
let print (board: Board) =
    printfn "\n+-------+-------+-------+"
    for row in 0..8 do
        printf "| "
        for col in 0..8 do
            let v = board.[row, col]
            if v = 0 then printf ". "
            else printf "%d " v

            if (col + 1) % 3 = 0 then printf "| "
        printfn ""
        if (row + 1) % 3 = 0 then
            printfn "+-------+-------+-------+"

// Print simple format (9 lines of numbers)
let printSimple (board: Board) =
    for row in 0..8 do
        for col in 0..8 do
            printf "%d" board.[row, col]
            if col < 8 then printf " "
        printfn ""

// Save board to simple 9×9 txt file
let saveToFile (board: Board) (filename: string) : bool =
    try
        use w = new System.IO.StreamWriter(filename)
        for row in 0..8 do
            for col in 0..8 do
                w.Write(board.[row, col])
                if col < 8 then w.Write(" ")
            w.WriteLine()
        true
    with _ ->
        false

// Find the first empty cell
let findEmptyCell (board: Board) : (int * int) option =
    let mutable result = None

    for row in 0..8 do
        for col in 0..8 do
            if result.IsNone && board.[row, col] = 0 then
                result <- Some (row, col)

    result