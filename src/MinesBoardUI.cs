using System.Drawing;
using System.Windows.Forms;

public class MinesBoardUI : UserControl
{
    private const int CELL_SIZE = 28;
    private MinesBoard _board = new MinesBoard(9, 9, 10);
    private readonly Color[] _foreColors =
    {
        Color.Blue, Color.Green, Color.Red, Color.Purple,
        Color.Maroon, Color.Teal, Color.Black, Color.Gray
    };

    public event EventHandler? CellClick;
    public event EventHandler? MinesExplode;

    public int MinesCount => _board.MinesCount;
    public int FlagsCount => _board.FlagsCount;
    public bool IsLost => _board.IsLost;
    public bool IsFinish => _board.IsFinish;

    public MinesBoardUI()
    {
        DoubleBuffered = true;
        NewGame(9, 9, 10);
    }

    public void NewGame(int rows, int cols, int mines)
    {
        _board = new MinesBoard(rows, cols, mines);
        Size = new Size(cols * CELL_SIZE + 1, rows * CELL_SIZE + 1);
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.Clear(Color.LightGray);

        for (int i = 0; i < _board.Rows; i++)
        {
            for (int j = 0; j < _board.Cols; j++)
            {
                int x = j * CELL_SIZE, y = i * CELL_SIZE;
                Cell cell = _board[i, j];

                if (!cell.IsOpened)
                    g.FillRectangle(Brushes.Silver, x + 1, y + 1, CELL_SIZE - 2, CELL_SIZE - 2);

                if (cell.IsOpened && cell.IsMine)
                    g.FillRectangle(Brushes.Red, x + 1, y + 1, CELL_SIZE - 1, CELL_SIZE - 1);

                if (cell.IsOpened && !cell.IsMine && cell.MinesAround > 0)
                    DrawCenter(g, cell.MinesAround.ToString(),
                            _foreColors[cell.MinesAround - 1], x, y);

                if (_board.IsLost && cell.IsMine)       
                    g.FillEllipse(Brushes.Black, x + 7, y + 7, CELL_SIZE - 14, CELL_SIZE - 14);

                if (cell.IsFlag)
                    DrawCenter(g, "F", Color.Red, x, y);
                else if (cell.IsMarked)
                    DrawCenter(g, "?", Color.Black, x, y);

                g.DrawRectangle(Pens.Gray, x, y, CELL_SIZE, CELL_SIZE);
            }
        }
        base.OnPaint(e);
    }

    private void DrawCenter(Graphics g, string s, Color color, int x, int y)
    {
        using var font = new Font("Segoe UI", 11, FontStyle.Bold);
        using var brush = new SolidBrush(color);
        SizeF size = g.MeasureString(s, font);
        g.DrawString(s, font, brush,
            x + (CELL_SIZE - size.Width) / 2, y + (CELL_SIZE - size.Height) / 2);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (!_board.IsLost && !_board.IsFinish)
        {
            int c = e.X / CELL_SIZE, r = e.Y / CELL_SIZE;
            if (r < 0 || c < 0 || r >= _board.Rows || c >= _board.Cols) return;

            Cell cell = _board[r, c];
            if (cell.IsOpened) return;

            if (e.Button == MouseButtons.Left && !cell.IsFlag)
            {
                cell.IsMarked = false;
                if (_board.OpenCell(r, c))
                {
                    _board.IsLost = true;
                    MinesExplode?.Invoke(this, EventArgs.Empty);
                }
                else if (_board.RemainCellsCount == _board.MinesCount)
                {
                    _board.IsFinish = true;
                    for (int i = 0; i < _board.Rows; i++)
                        for (int j = 0; j < _board.Cols; j++)
                            if (!_board[i, j].IsOpened) _board[i, j].IsFlag = true;
                    _board.FlagsCount = _board.MinesCount;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (cell.IsMarked)
                {
                    cell.IsMarked = false;
                }
                else
                {
                    cell.IsFlag = !cell.IsFlag;
                    cell.IsMarked = !cell.IsFlag;
                    _board.FlagsCount += cell.IsFlag ? 1 : -1;
                }
            }
            Invalidate();
            CellClick?.Invoke(this, EventArgs.Empty);
        }
        base.OnMouseDown(e);
    }
}