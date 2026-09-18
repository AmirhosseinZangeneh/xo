## Portfolio Context

This project represents the beginning of my C# learning journey and focuses on fundamental programming concepts before moving into desktop applications and larger backend systems.

# XO Game

A simple console-based Tic-Tac-Toe game written in C#. Two players take turns placing `X` and `O` on a 3×3 board until one player wins or the board is full.

## Features

- Two-player local gameplay
- Input validation for non-numeric and out-of-range values
- Occupied-cell validation
- Win detection for rows, columns, and diagonals
- Draw detection
- Replay option after each game
- Clear console board display

## Tech Stack

- C#
- .NET Framework 4.8
- Console application

## Requirements

- Windows
- Visual Studio 2019 or 2022 with the .NET Framework 4.8 Developer Pack

## Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/AmirhosseinZangeneh/xo.git
   ```

2. Open [`xo.sln`](xo.sln) in Visual Studio.
3. Build and run the project.
4. During the game, enter a number from `1` to `9` to choose a board cell.

## Board Input

The board starts with these cell numbers:

```text
 1 | 2 | 3
---|---|---
 4 | 5 | 6
---|---|---
 7 | 8 | 9
```

## Learning Goals

This project is an introductory C# exercise covering arrays, loops, methods, conditions, input validation, and basic game-state management. It is the first step in the C# portfolio path before the Windows Forms `ContactManager` project.
