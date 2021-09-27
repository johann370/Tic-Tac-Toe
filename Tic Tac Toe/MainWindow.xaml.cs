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

            if (checkIfBoxEmpty(button))
            {
                changeText(button, playerToMove);
                squaresLeft--;
                updateGrid(button);
                if (squaresLeft <= 5)
                {
                    if (checkWin(button))
                    {
                        playerLabel.Content = $"{playerToMove} Wins";
                    }
                }
                changePlayer();
            }
        }

        private bool checkIfBoxEmpty(Button button)
        {
            int row = Grid.GetRow(button);
            int col = Grid.GetColumn(button);

            if(grid[row, col] == "")
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
            if (checkCol(col))
            {
                return true;
            }
            if (row - col != 1 && row - col != -1)
            {
                if (checkDiagonal(row, col))
                {
                    return true;
                }
            }
            return false;
        }

        private bool checkDiagonal(int row, int col)
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
