# Minesweeper

A classic Minesweeper game built with C# and Windows Forms.

## Features

- Classic Minesweeper gameplay
- Randomly placed mines on every new game
- Left click to reveal a cell, right click to place a flag
- Automatic reveal of empty neighboring cells

## Requirements

- Windows 10 or later
- [.NET SDK](https://dotnet.microsoft.com/download) (check your version with `dotnet --version`)

## Getting Started

Clone the repository and run the game:

```bash
git clone https://github.com/HTrNhatAhh/Minesweeper.git
cd Minesweeper
dotnet run --project src
```

You can also open `Minesweeper.slnx` in Visual Studio and press **F5** to run.

## Project Structure

```
Minesweeper/
├── src/                 # Game source code
│   ├── Program.cs       # Application entry point
│   ├── Form1.cs         # Main game window
│   └── ...
├── Minesweeper.sln      # Visual Studio solution file
└── README.md
```

## How to Play

| Action | Control |
|---|---|
| Reveal a cell | Left click |
| Place or remove a flag | Right click |

- Numbers show how many mines are in the 8 neighboring cells.
- Reveal every cell that does not contain a mine to win.
- Revealing a mine ends the game.

## Contributing

1. Fork the repository
2. Create a new branch: `git checkout -b feature/your-feature`
3. Commit your changes: `git commit -m "Add your feature"`
4. Push to your branch: `git push origin feature/your-feature`
5. Open a Pull Request

## Author

[HTrNhatAhh](https://github.com/HTrNhatAhh)
