module Sudoku

open Board

// Check if a value is valid in a specific row
let isValidInRow (board: Board.Board) row value : bool =
    let rowValues = Board.getRow board row
    not (List.contains value rowValues)

// Check if a value is valid in a specific column
let isValidInCol (board: Board.Board) col value : bool =
    let colValues = Board.getCol board col
    not (List.contains value colValues)

// Check if a value is valid in the 3x3 box
let isValidInBox (board: Board.Board) row col value : bool =
    let boxValues = Board.getBox board row col
    not (List.contains value boxValues)

// Check if a value is valid at position (row, col)
// Must satisfy all three constraints: row, column, and box
let isValid (board: Board.Board) row col value : bool =
    isValidInRow board row value &&
    isValidInCol board col value &&
    isValidInBox board row col value

// Check if the initial board is valid (no duplicate values in filled cells)
let isValidBoard (board: Board.Board) : bool =
    let mutable valid = true
    let mutable row = 0
    
    while row < 9 && valid do
        let mutable col = 0
        while col < 9 && valid do
            let value = Board.getCell board row col
            if value <> 0 then
                // Temporarily set to 0 to check if value would be valid
                let tempBoard = Board.setCell board row col 0
                if not (isValid tempBoard row col value) then
                    valid <- false
            col <- col + 1
        row <- row + 1
    valid

// Main recursive backtracking solver
// Returns Some board if solution found, None if no solution exists
let rec solve (board: Board.Board) : Board.Board option =
    match Board.findEmptyCell board with
    | None -> 
        Some board
    
    | Some (row, col) ->
        // Try values 1-9 in this empty cell
        let rec tryValues value =
            if value > 9 then
                // Exhausted all values, backtrack
                None
            elif isValid board row col value then
                // Value is valid, place it and recurse
                let newBoard = Board.setCell board row col value
                match solve newBoard with
                | Some solvedBoard -> Some solvedBoard  // Solution found!
                | None -> tryValues (value + 1)         // Backtrack, try next value
            else
                // Value not valid, try next
                tryValues (value + 1)
        
        tryValues 1

// Solve with validation - checks if initial board is valid first
let solveWithValidation (board: Board.Board) : Board.Board option =
    if isValidBoard board then
        solve board
    else
        None