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
            changeText(button, playerToMove);
            changePlayer();
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
            if(playerToMove == "Player 1")
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
