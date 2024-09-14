using System.Diagnostics;

namespace Tetris
{
    sealed internal class GameGrid
    {
        private static readonly int ROWS = 22;
        private static readonly int COLUMNS = 10;
        private static readonly int FULL_BIT = 1024;

        private readonly int[,] GRID = new int[ROWS, COLUMNS];
        private readonly int[] SENTIENL_ROW_VALUES = new int[ROWS];

        public bool IsInside(int row, int col)
        {
            return row >= 0 && row < ROWS && col >= 0 && col < COLUMNS;
        }

        public bool IsEmpty(int row, int col)
        {
            return IsInside(row, col) && GRID[row, col] == 0;
        }

        public bool IsRowFull(int row)
        {
            return (SENTIENL_ROW_VALUES[row] & FULL_BIT) == FULL_BIT;
        }

        public void ClearRow(int row)
        {
            for (int col = 0; col < COLUMNS; ++col)
            {
                GRID[row, col] = 0;
            }

            SENTIENL_ROW_VALUES[row] = 0;
        }

        private void moveRowDown(int row, uint downCount)
        {
            for (int col = 0; col < COLUMNS; ++col)
            {
                Debug.Assert(GRID[row + downCount, col] == 0, "Full rows are not cleared");
                GRID[row + downCount, col] = GRID[row, col];

                Debug.Assert(SENTIENL_ROW_VALUES[row + downCount] == 0, "SENTINEL_ROW_VALUES are not changed");
                SENTIENL_ROW_VALUES[row + downCount] = SENTIENL_ROW_VALUES[row];
            }
        }

        public uint ClearFullRows()
        {
            uint clearedRows = 0;

            for (int row = ROWS - 1; row >= 0; --row)
            {
                if (IsRowFull(row))
                {
                    ClearRow(row);
                    ++clearedRows;
                }
                else if (clearedRows > 0)
                {
                    moveRowDown(row, clearedRows);
                    ClearRow(row);
                }
            }

            return clearedRows;
        }
    }
}
