module Program

open System
open System.Diagnostics
open Board
open Sudoku

[<EntryPoint>]
let main argv =
    printfn "======================================"
    printfn "  SUDOKU SOLVER - FUNCTIONAL PARADIGM"
    printfn "======================================"
    printfn ""
    
    // Input file name
    let inputFile = "input.txt"
    let outputFile = "output.txt"
    
    printfn "Loading puzzle from '%s'..." inputFile
    
    // Load the puzzle from file
    match Board.loadFromFile inputFile with
    | None ->
        printfn "Failed to load puzzle from file."
        printfn "Please ensure '%s' exists and is properly formatted." inputFile
        1 // Error exit code
    
    | Some board ->
        printfn "Puzzle loaded successfully!\n"
        printfn "Initial Puzzle:"
        Board.print board
        printfn ""
        
        // Start timing
        let stopwatch = Stopwatch.StartNew()
        
        // Solve the puzzle
        printfn "Solving..."
        let result = Sudoku.solveWithValidation board
        
        // Stop timing
        stopwatch.Stop()
        
        printfn ""
        
        // Display results
        match result with
        | None ->
            printfn "No solution exists for the given puzzle."
            printfn "The initial board may violate Sudoku constraints."
            printfn ""
            printfn "--- EVALUATION METRICS ---"
            printfn "Execution Time: %d ms" stopwatch.ElapsedMilliseconds
            printfn "Status: UNSOLVABLE"
            1 // Error exit code
        
        | Some solvedBoard ->
            printfn "Solved Successfully!\n"
            printfn "Solution:"
            Board.print solvedBoard
            printfn ""
            
            // Save to output file
            if Board.saveToFile solvedBoard outputFile then
                printfn "Solution saved to '%s'" outputFile
            else
                printfn "Warning: Could not save solution to file."
            
            printfn ""
            printfn "======================================"
            printfn "       EVALUATION METRICS"
            printfn "======================================"
            printfn "Execution Time: %d ms (%.3f seconds)" 
                stopwatch.ElapsedMilliseconds 
                (float stopwatch.ElapsedMilliseconds / 1000.0)
            
            // Memory usage (approximate)
            let currentProcess = Process.GetCurrentProcess()
            let memoryUsed = currentProcess.WorkingSet64 / 1024L / 1024L
            printfn "Memory Usage: ~%d MB" memoryUsed
            
            printfn "Status: SUCCESS"
            printfn "Algorithm: Recursive Backtracking (DFS)"
            printfn "Paradigm: Functional Programming (F#)"
            printfn "======================================"
            printfn ""
            
            0 