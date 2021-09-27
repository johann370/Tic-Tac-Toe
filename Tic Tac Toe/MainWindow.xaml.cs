using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string playerToMove;
        string[,] grid;
        int squaresLeft;
        bool gameOver = false;
        public MainWindow()
        {
            InitializeComponent();

            startGame();
        }

        private void startGame()
        {
            playerToMove = "Player 1";
            grid = new string[3, 3] { { "", "", "" }, { "", "", "" }, { "", "", "" } };
            squaresLeft = 9;
        }

        private void clickBox(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (checkIfBoxEmpty(button) && !gameOver)
            {
                changeText(button, playerToMove);
                squaresLeft--;
                updateGrid(button);
                if (squaresLeft <= 5)
                {
                    if (checkWin(button))
                    {
                        endGame(button, playerToMove);
                    }
                }
                changePlayer();
                if(squaresLeft == 0)
                {
                    endGame(button, "Tie");
                }
            }
        }

        private void endGame(Button button, String winner)
        {
            int row = Grid.GetRow(button);
            int col = Grid.GetColumn(button);

            playerLabel.Content = winner != "Tie" ? $"{winner} Wins" : "It's a tie";

            if (checkRow(row))
            {
                drawLine("row", row);
            }
            else if (checkCol(col))
            {
                drawLine("column", col);
            }
            else if (checkDiagonals(row, col))
            {
                if (row - col == 0)
                {
                    drawLine("topLeftToBottomRight");
                }
                else
                {
                    drawLine("bottomLeftToTopRight");
                }
            }
            gameOver = true;
        }

        private void drawLine(string direction, int num = 0)
        {
            if (direction == "row")
            {
                Rectangle line = new Rectangle();
                line.Width = 300;
                line.Height = 10;
                line.Fill = Brushes.Black;
                line.HorizontalAlignment = HorizontalAlignment.Left;
                line.VerticalAlignment = VerticalAlignment.Center;
                Grid.SetRow(line, num);
                Grid.SetColumnSpan(line, 3);
                gameWindow.Children.Add(line);
            }
            else if (direction == "column")
            {
                Rectangle line = new Rectangle();
                line.Width = 10;
                line.Height = 300;
                line.Fill = Brushes.Black;
                line.HorizontalAlignment = HorizontalAlignment.Center;
                line.VerticalAlignment = VerticalAlignment.Center;
                Grid.SetColumn(line, num);
                Grid.SetRowSpan(line, 3);
                gameWindow.Children.Add(line);
            }
            else if (direction == "topLeftToBottomRight")
            {
                Rectangle line = new Rectangle();
                line.Width = 500;
                line.Height = 10;
                line.Fill = Brushes.Black;
                line.HorizontalAlignment = HorizontalAlignment.Left;
                line.VerticalAlignment = VerticalAlignment.Top;
                line.RenderTransform = new SkewTransform(-45, 45);
                Grid.SetRow(line, 0);
                Grid.SetColumn(line, 0);
                Grid.SetColumnSpan(line, 3);
                Grid.SetRowSpan(line, 3);
                gameWindow.Children.Add(line);
            }
            else if (direction == "bottomLeftToTopRight")
            {
                Rectangle line = new Rectangle();
                line.Width = 500;
                line.Height = 10;
                line.Fill = Brushes.Black;
                line.HorizontalAlignment = HorizontalAlignment.Left;
                line.VerticalAlignment = VerticalAlignment.Bottom;
                line.RenderTransform = new SkewTransform(45, -45);
                Grid.SetRow(line, 2);
                Grid.SetColumn(line, 0);
                Grid.SetColumnSpan(line, 3);
                Grid.SetRowSpan(line, 3);
                gameWindow.Children.Add(line);
            }
        }

        private bool checkIfBoxEmpty(Button button)
        {
            int row = Grid.GetRow(button);
            int col = Grid.GetColumn(button);

            if (grid[row, col] == "")
            {
                return true;
            }

            return false;
        }

        private void updateGrid(Button button)
        {
            int row = Grid.GetRow(button);
            int col = Grid.GetColumn(button);
            grid[row, col] = playerToMove == "Player 1" ? "X" : "O";
        }

        private bool checkWin(Button button)
        {
            int row = Grid.GetRow(button);
            int col = Grid.GetColumn(button);
            if (checkRow(row))
            {
                return true;
            }
            else if (checkCol(col))
            {
                return true;
            }
            else if (row - col != 1 && row - col != -1)
            {
                if (checkDiagonals(row, col))
                {
                    return true;
                }
            }
            return false;
        }

        private bool checkDiagonals(int row, int col)
        {
            if (row - col == 0)
            {
                if (grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2])
                {
                    return true;
                }
            }
            else if (row - col == 2 || row - col == -2)
            {
                if (grid[2, 0] == grid[1, 1] && grid[1, 1] == grid[0, 2])
                {
                    return true;
                }
            }

            return false;
        }

        private bool checkCol(int col)
        {
            if (grid[0, col] == grid[1, col] && grid[1, col] == grid[2, col])
            {
                return true;
            }

            return false;
        }

        private bool checkRow(int row)
        {
            if (grid[row, 0] == grid[row, 1] && grid[row, 1] == grid[row, 2])
            {
                return true;
            }

            return false;
        }

        private void changePlayer()
        {
            if (playerToMove == "Player 1")
            {
                playerToMove = "Player 2";
            }
            else if (playerToMove == "Player 2")
            {
                playerToMove = "Player 1";
            }
        }

        private void changeText(Button button, string playerToMove)
        {
            if (playerToMove == "Player 1")
            {
                button.Content = "X";
                playerLabel.Content = "Player 2's Turn";
            }
            else if (playerToMove == "Player 2")
            {
                button.Content = "O";
                playerLabel.Content = "Player 1's Turn";
            }
        }
    }
}
