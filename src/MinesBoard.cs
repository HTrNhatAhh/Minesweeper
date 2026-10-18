public class MinesBoard
{
    private Cell[,] _cells = null!;
    private Random _rnd = new Random();

    public int Rows { get; private set; }
    public int Cols { get; private set; }
    public int MinesCount { get; private set; }
    public int FlagsCount;
    public int OpenedCellsCount;
    public bool IsLost;
    public bool IsFinish;

    public int CellsCount => Rows * Cols;
    public int RemainCellsCount => CellsCount - OpenedCellsCount;
    public Cell this[int r, int c] => _cells[r, c];

    public MinesBoard(int rows, int cols, int mines)
    {
        Rows = rows;
        Cols = cols;
        MinesCount = mines;
        InitBoard();
    }

    private void InitBoard()
    {
        _cells = new Cell[Rows, Cols];
        for (int r = 0; r < Rows; r++)
            for (int c = 0; c < Cols; c++)
                _cells[r, c] = new Cell();

        int count = 0;
        while (count < MinesCount)
        {
            int index = _rnd.Next(CellsCount);
            int r = index / Cols, c = index % Cols;
            if (!_cells[r, c].IsMine)
            {
                _cells[r, c].IsMine = true;
                count++;
            }
        }
    }

    private int CountAroundMines(int row, int col)
    {
        int count = 0;
        for (int i = Math.Max(row - 1, 0); i <= Math.Min(row + 1, Rows - 1); i++)
            for (int j = Math.Max(col - 1, 0); j <= Math.Min(col + 1, Cols - 1); j++)
                if (_cells[i, j].IsMine) count++;
        return count;
    }

    public bool OpenCell(int row, int col)
    {
        Cell cell = _cells[row, col];
        if (cell.IsOpened || cell.IsFlag) return false;

        cell.IsOpened = true;
        if (cell.IsMine) return true;
        OpenedCellsCount++;

        int count = CountAroundMines(row, col);
        if (count > 0)
        {
            cell.MinesAround = count;
        }
        else
        {
            for (int i = Math.Max(row - 1, 0); i <= Math.Min(row + 1, Rows - 1); i++)
                for (int j = Math.Max(col - 1, 0); j <= Math.Min(col + 1, Cols - 1); j++)
                    OpenCell(i, j);
        }
        return false;
    }
}