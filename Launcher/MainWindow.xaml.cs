using Client.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Launcher
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        private static List<GameIcon> totalGameList;
        public static GameIconList gameIconList;


        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("{0} / {1}", SystemParameters.PrimaryScreenWidth, this.Width);
            Console.WriteLine("{0} / {1}", SystemParameters.PrimaryScreenHeight, this.Height);
            this.Left = (SystemParameters.PrimaryScreenWidth / 2) - (this.Width/2);
            this.Top = SystemParameters.PrimaryScreenHeight - this.Height - 100;

            gameIconList = Resources["GameIconKey"] as GameIconList;

            string appFolder = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            using (StreamReader sr = new StreamReader(appFolder + "\\data\\gameList.data"))
            {
                string json = sr.ReadToEnd();
                Console.WriteLine(json);
                totalGameList = JsonConvert.DeserializeObject<List<GameIcon>>(json);
            }

            Console.Write("totalGameList: {0}", totalGameList);

            foreach (var game in totalGameList)
            {
                Console.Write(game);
                Icon fileIcon = System.Drawing.Icon.ExtractAssociatedIcon(game.Path);

                try
                {
                    ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(
                                                    fileIcon.Handle,
                                                    Int32Rect.Empty,
                                                    BitmapSizeOptions.FromEmptyOptions());
                    game.IconImage = imageSource;
                } catch
                {

                }
                gameIconList.Add(game);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            Launcher.MainWindow.gameIconList.Clear();
            List<GameIcon> searchedList = totalGameList.FindAll(x => x.Name.ToString().ToUpper().IndexOf(GameSearchString.Text.Trim().ToUpper()) > -1);
            foreach (var game in searchedList)
            {
                Launcher.MainWindow.gameIconList.Add(game);
            }

            GameList.Visibility = Visibility.Visible;
        }

        private void GameList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LauncherMain_Activated(object sender, EventArgs e)
        {
            GameSearchString.Focus();
        }

        #region 장르선택버튼 마우스 클릭 이벤트

        private void InternetBtn_Click(object sender, MouseButtonEventArgs e)
        {
            Process.Start("iexplore.exe");
        }

        private void PopGameMouseDown(object sender, MouseButtonEventArgs e)
        {
            Contents.Visibility = Contents.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        private void OnlineGameBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Launcher.MainWindow.gameIconList.Clear();
            // List<GameIcon> searchedList = totalGameList.FindAll(x => x.Type.Equals("FPS"));
            // foreach (var game in searchedList)
            // {
//                Launcher.MainWindow.gameIconList.Add(game);
  //          }
        }

        private void MobileGameBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void WebGameBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void FpsGameBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void SportsGameBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void CasualGameBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void BoardGameBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void CdGameBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        #endregion
    }
}
