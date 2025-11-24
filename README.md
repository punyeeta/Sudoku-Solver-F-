# Recursive Constraint Satisfaction with Matrix-Driven Sudoku Solver using Depth-First Search Algorithm

This program is a console-based Sudoku solver for standard 9×9 puzzles. It uses recursive backtracking and constraint validation to systematically place digits, backtracking when rules are violated to ensure a valid solution.

Sudoku is treated as a **Constraint Satisfaction Problem (CSP)**, making it ideal for demonstrating logical reasoning, algorithmic precision, and different programming paradigms in problem-solving. The solver highlights how structured, rule-based problems can be approached efficiently using algorithmic methods.

---

## Prerequisites

Before running the program, ensure you have the following installed:

- **.NET SDK 7.0 or higher** (includes `dotnet` CLI)  
- **A code editor or IDE** (Visual Studio, Visual Studio Code, Rider, etc.)  
- **Optional:** Ionide extension for Visual Studio Code (enhances F# support)  

---

## Getting Started

### 1. Clone the repository
```
git clone https://github.com/yourusername/your-repo.git
cd your-repo
```

### 2. Build the project
Navigate to the folder containing the .fsproj file and run:
```
dotnet build
```
This will compile your F# project and ensure there are no errors.

### 3. Run the program
After building, run the application using:
```
dotnet run --project YourProjectName.fsproj
```
Replace *YourProjectName* with the actual project file name.

### 4. Input instructions (if applicable)
If your program requires user input (e.g., a Sudoku board), input numbers row by row. Use 0 for empty cells.

Example Input:
```
5 3 0 0 7 0 0 0 0
6 0 0 1 9 5 0 0 0
0 9 8 0 0 0 0 6 0
8 0 0 0 6 0 0 0 3
4 0 0 8 0 3 0 0 1
7 0 0 0 2 0 0 0 6
0 6 0 0 0 0 2 8 0
0 0 0 4 1 9 0 0 5
0 0 0 0 8 0 0 7 9
```

## Features
- Solves Sudoku boards of any difficulty
- Outputs solved board in console
- Validates input before solving

## Troubleshooting
- If you see command not found: dotnet, ensure the .NET SDK is installed and added to your PATH.
- For build errors, check that all .fs files are included in the .fsproj file in the correct order.
