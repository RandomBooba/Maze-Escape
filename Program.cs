namespace Maze_Escape
{
    using System;

    class Program
    {
        // Define the maze as a 2D character array
        // '#' represents walls, ' ' represents open paths, 'P' is the player's starting position,

        static char[,] maze = {
        { '#', '#', '#', '#', '#', ' ', '#', '#' },
        { '#', ' ', ' ', ' ', '#', ' ', ' ', '#' },
        { '#', ' ', '#', ' ', '#', '#', ' ', '#' },
        { '#', 'P', '#', ' ', ' ', ' ', ' ', '#' },
        { '#', '#', '#', '#', '#', '#', '#', '#' }
    };

        // Store the player's current position in the maze
        static int playerRow = 3;  // Starting row for player
        static int playerCol = 1;  // Starting column for player

        static void Main()
        {
            // Display instructions for the player
            Console.WriteLine("Use W (up), A (left), S (down), D (right) to move. Type Q to quit.");

            // Display the initial state of the maze
            PrintMaze();

            // Main game loop
            while (true)
            {
                // Capture a single key input from the player
                char move = Console.ReadKey(true).KeyChar;  // 'true' hides the key input in the console
                move = char.ToUpper(move);  // Convert to uppercase to make the input case-insensitive

                // Check if the player wants to quit
                if (move == 'Q') break;

                // Attempt to move the player based on the input
                if (MovePlayer(move))
                {
                    // Re-print the maze with the updated player position
                    PrintMaze();

                    // Check if the player has reached the exit
                }
            }
        }

        // Function to print the current state of the maze
        static void PrintMaze()
        {
            Console.Clear();  // Clear the console for a fresh display
            for (int row = 0; row < maze.GetLength(0); row++)  // Loop through rows
            {
                for (int col = 0; col < maze.GetLength(1); col++)  // Loop through columns
                {
                    Console.Write(maze[row, col] + " ");  // Print each cell with a space for readability
                }
                Console.WriteLine();  // Move to the next line after each row
            }
            // Tells the player to move out of the maze to win by crashing it
            Console.SetCursorPosition(20, 0);
            Console.Write("Crash the game to win");
        }

        // Function to handle player movement
        // Returns true if the move was successful, false if blocked by a wall
        static bool MovePlayer(char direction)
        {
            // Temporary variables to store the new player position
            int newRow = playerRow, newCol = playerCol;

            // Update position based on the direction input
            if (direction == 'W') newRow--;        // Move up
            else if (direction == 'S') newRow++;   // Move down
            else if (direction == 'A') newCol--;   // Move left
            else if (direction == 'D') newCol++;   // Move right

            // Check if the new position is valid (not a wall '#')
            if (maze[newRow, newCol] != '#')
            {
                maze[playerRow, playerCol] = ' ';  // Clear the old player position
                playerRow = newRow;  // Update to new row
                playerCol = newCol;  // Update to new column
                maze[playerRow, playerCol] = 'P';  // Place player in the new position
                return true;  // Return true indicating the move was successful
            }

            return false;  // Return false if the move is blocked by a wall
        }
    }

}
