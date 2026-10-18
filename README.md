# Minesweeper

A classic Minesweeper game built with C# and Windows Forms.

Please use **.NET SDK 10.0 or above** (check with `dotnet --version`).

## 1. Git and GitHub

- Install Git: https://git-scm.com/
- In VS Code, sign in to GitHub.
- Open the Source Control tab (branch icon).
- Click **Clone Repository**, choose `Clone from GitHub`, then choose `Minesweeper`, then pick a folder to save the project.
- Remember that folder, it is your project working place.
- Next time you code, open the `Minesweeper` folder in VS Code.
- Git quick guide: https://github.com/git-guides

### Git Configuration

Before you use Git, enter these commands in the terminal (replace with your GitHub username and email):

```
git config --global user.name "Your Name"
```

```
git config --global user.email "your.email@example.com"
```

### Commit and Push in VS Code (GUI)

1. After editing files, open Source Control.
2. Click "+" next to each file you want to save.
3. Enter a commit message (what you just coded or did).
4. Click the dropdown "v" near Commit, then choose **Commit & Push**.
5. To get the latest changes from teammates, click the three dots "..." near the repository title in Source Control, then choose **Pull**.

## 2. Run the Game

Using the terminal:

```
dotnet run --project src
```

Or open `Minesweeper.slnx` in Visual Studio and press **F5**.

## 3. Project Structure

```
Minesweeper/
├── src/                  # Game source code
│   ├── Program.cs        # Application entry point
│   ├── Form1.cs          # Main game window
│   └── ...
├── .gitignore
├── Minesweeper.slnx      # Solution file
└── README.md
```

## 4. How to Play

| Action | Control |
|---|---|
| Reveal a cell | Left click |
| Place or remove a flag | Right click |

- Numbers show how many mines are in the 8 neighboring cells.
- Reveal every cell that does not contain a mine to win.
- Revealing a mine ends the game.

## 5. Author

[HTrNhatAhh](https://github.com/HTrNhatAhh)
