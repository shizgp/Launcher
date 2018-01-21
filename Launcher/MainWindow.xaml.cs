using Client.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Launcher
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public static GameIconList gameIconList;

        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("{0} / {1}", SystemParameters.PrimaryScreenWidth, this.Width);
            Console.WriteLine("{0} / {1}", SystemParameters.PrimaryScreenHeight, this.Height);
            this.Left = (SystemParameters.PrimaryScreenWidth / 2) - (this.Width/2);
            this.Top = SystemParameters.PrimaryScreenHeight - this.Height - 100;

            gameIconList = Resources["GameIconKey"] as GameIconList;
            GameIcon gameIcon = new GameIcon("Warcraft 3");
            gameIconList.Add(gameIcon);

            gameIcon = new GameIcon("Starcraft HD");
            gameIconList.Add(gameIcon);

            gameIcon = new GameIcon("Diablo III");
            gameIconList.Add(gameIcon);

            gameIcon = new GameIcon("PlayUnknown's BattleGrounds");
            gameIconList.Add(gameIcon);

            for(var i = 0; i < 100; i++)
            {
                gameIcon = new GameIcon("Game "+i);
                gameIconList.Add(gameIcon);
            }

            // Icon IEIcon = Icon.ExtractAssociatedIcon(@"C:\Program Files\Internet Explorer\iexplore.exe");
            // Image im = IEIcon.ToBitmap();

        }

        private void PopGameMouseDown(object sender, MouseButtonEventArgs e)
        {
            Contents.Visibility = Contents.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        private void InternetBtn_Click(object sender, MouseButtonEventArgs e)
        {
            Process.Start("iexplore.exe");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TotalGameList totalGameList = new TotalGameList();
            Console.WriteLine(GameSearchString.Text);
            totalGameList.FindGameBySearchString(GameSearchString.Text);
        }
    }

    public class TotalGameList
    {
        List<GameIcon> totalList = new List<GameIcon>();

        public TotalGameList()
        {
            InitTotalGameList();
        }

        internal void InitTotalGameList()
        {
            // get data from json or manager program.
            for(var i=0; i < 50; i++)
            {
                GameIcon gameIcon = new GameIcon("Game "+i);
                totalList.Add(gameIcon);
            }
        }

        internal void FindGameBySearchString(string searchText)
        {
            Launcher.MainWindow.gameIconList.Clear();
            List<GameIcon> searchedList = totalList.FindAll(x => searchText.ToUpper().IndexOf(x.GameName.ToUpper()) > -1);
            Console.WriteLine(searchedList.Count);
            foreach(var game in searchedList)
            {
                Launcher.MainWindow.gameIconList.Add(game);
            }
        }
    }
}
