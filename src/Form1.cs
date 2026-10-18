namespace Minesweeper;

public partial class Form1 : Form
{
    private const int ROWS = 10;
    private const int COLS = 10;
    private const int MINES = 10;
    private readonly MinesBoardUI _board = new MinesBoardUI();
    private readonly Label _lblStatus = new Label();
    private readonly Button _btnNew = new Button();

    public Form1()
    {
        InitializeComponent();
        AutoScaleMode = AutoScaleMode.None;
        SetupUI();
        UpdateStatus();
    }

    private void SetupUI()
    {
        Text = "Minesweeper";
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

        _lblStatus.AutoSize = true;
        _lblStatus.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        _lblStatus.Location = new Point(10, 16);

        _btnNew.Text = "New Game";
        _btnNew.Size = new Size(100, 30);
        _btnNew.Click += (s, e) => StartNewGame();

        _board.Location = new Point(10, 50);
        _board.NewGame(ROWS, COLS, MINES);
        _board.CellClick += (s, e) => UpdateStatus();

        Controls.Add(_lblStatus);
        Controls.Add(_btnNew);
        Controls.Add(_board);

        ClientSize = new Size(_board.Width + 20, _board.Height + 60);
        _btnNew.Location = new Point(ClientSize.Width - _btnNew.Width - 10, 10);
    }

    private void StartNewGame()
    {

        _board.NewGame(ROWS, COLS, MINES);
        UpdateStatus();
    }

    private void UpdateStatus()
    {
        if (_board.IsLost)
            _lblStatus.Text = "Game over! You hit a mine.";
        else if (_board.IsFinish)
            _lblStatus.Text = "You win!";
        else
            _lblStatus.Text = $"Mines left: {_board.MinesCount - _board.FlagsCount}";
    }
}