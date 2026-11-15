
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MazeGameGUI
{
    public partial class Form1 : Form
    {
        // Maze map
        private char[,] maze =
        {
            {'#','#','#','#','#','#','#','#','#','#','#'},
            {'#',' ',' ',' ','#',' ',' ',' ',' ',' ','#'},
            {'#',' ','#',' ','#',' ','#','#','#',' ','#'},
            {'#',' ','#',' ',' ',' ',' ',' ','#',' ','#'},
            {'#',' ','#','#','#','#','#',' ','#',' ','#'},
            {'#',' ',' ',' ',' ',' ','#',' ',' ',' ','#'},
            {'#','#','#','#','#',' ','#','#','#',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ','#',' ','#'},
            {'#',' ','#','#','#','#','#',' ','#','E','#'},
            {'#','#','#','#','#','#','#','#','#','#','#'}
        };

        private int playerX = 1;
        private int playerY = 1;

        private int moves = 0;
        private int seconds = 0;

        private bool gameOver = false;

        private Panel gamePanel;
        private Label movesLabel;
        private Label timeLabel;
        private Button restartButton;

        private Timer gameTimer;

        private const int CellSize = 40;

        public Form1()
        {
            InitializeComponent();

            InitializeGame();
        }

        private void InitializeGame()
        {
            // Form settings
            this.Text = "Maze Game";
            this.Size = new Size(650, 530);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(25, 30, 45);

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            // Game panel
            gamePanel = new Panel();

            gamePanel.Location = new Point(20, 20);
            gamePanel.Size = new Size(440, 400);
            gamePanel.BackColor = Color.FromArgb(35, 42, 60);

            gamePanel.Paint += DrawMaze;

            this.Controls.Add(gamePanel);

            // Moves label
            movesLabel = new Label();

            movesLabel.Text = "Moves: 0";
            movesLabel.Location = new Point(480, 50);
            movesLabel.Size = new Size(130, 30);

            movesLabel.ForeColor = Color.White;
            movesLabel.Font = new Font("Arial", 12);

            this.Controls.Add(movesLabel);

            // Time label
            timeLabel = new Label();

            timeLabel.Text = "Time: 0";
            timeLabel.Location = new Point(480, 100);
            timeLabel.Size = new Size(130, 30);

            timeLabel.ForeColor = Color.White;
            timeLabel.Font = new Font("Arial", 12);

            this.Controls.Add(timeLabel);

            // Restart button
            restartButton = new Button();

            restartButton.Text = "Restart";
            restartButton.Location = new Point(480, 160);
            restartButton.Size = new Size(120, 40);

            restartButton.Click += RestartGame;

            this.Controls.Add(restartButton);

            // Game timer
            gameTimer = new Timer();

            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;

            gameTimer.Start();
        }

        // Draw maze
        private void DrawMaze(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    int x = j * CellSize;
                    int y = i * CellSize;

                    Rectangle cell = new Rectangle(
                        x, y, CellSize, CellSize
                    );

                    if (maze[i, j] == '#')
                    {
                        g.FillRectangle(Brushes.DarkSlateGray, cell);
                    }
                    else if (maze[i, j] == 'E')
                    {
                        g.FillRectangle(Brushes.Orange, cell);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.WhiteSmoke, cell);
                    }

                    g.DrawRectangle(Pens.Gray, cell);
                }
            }

            // Draw player
            int playerDrawX = playerY * CellSize;
            int playerDrawY = playerX * CellSize;

            g.FillEllipse(
                Brushes.DodgerBlue,
                playerDrawX + 5,
                playerDrawY + 5,
                CellSize - 10,
                CellSize - 10
            );
        }

        // Keyboard input
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameOver)
                return;

            int newX = playerX;
            int newY = playerY;

            // Handle movement keys
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.W:
                    newX--;
                    break;

                case Keys.Down:
                case Keys.S:
                    newX++;
                    break;

                case Keys.Left:
                case Keys.A:
                    newY--;
                    break;

                case Keys.Right:
                case Keys.D:
                    newY++;
                    break;

                default:
                    return;
            }

            // Check boundaries
            if (newX < 0 || newX >= maze.GetLength(0) ||
                newY < 0 || newY >= maze.GetLength(1))
            {
                return;
            }

            // Check wall
            if (maze[newX, newY] == '#')
            {
                return;
            }

            // Update player position
            playerX = newX;
            playerY = newY;

            moves++;

            movesLabel.Text = "Moves: " + moves;

            // Check win
            if (maze[playerX, playerY] == 'E')
            {
                gameOver = true;

                gameTimer.Stop();

                MessageBox.Show(
                    "Congratulations! You won!\n" +
                    "Total moves: " + moves,
                    "Game Over"
                );
            }

            // Redraw game
            gamePanel.Invalidate();

            // Mark key as handled
            e.Handled = true;
            e.SuppressKeyPress = true;
        }


        // Timer event
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            seconds++;

            timeLabel.Text = "Time: " + seconds;
        }

        // Restart game
        private void RestartGame(object sender, EventArgs e)
        {
            playerX = 1;
            playerY = 1;

            moves = 0;
            seconds = 0;

            gameOver = false;

            movesLabel.Text = "Moves: 0";
            timeLabel.Text = "Time: 0";

            gameTimer.Start();

            gamePanel.Invalidate();

            this.Focus();
        }
    }
}
