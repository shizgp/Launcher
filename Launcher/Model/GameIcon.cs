using Client.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Client.Model
{
    public class GameIconList : ObservableCollection<GameIcon> { }

    public class GameIcon
    {

        private string gameName;
        private string iconSource;

        public GameIcon(string gameName) {
            this.gameName = gameName;
            
            this.iconSource = "C:\\Users\\Sunny\\source\\repos\\Launcher\\Launcher\\Resources\\fps_hover.png";
        }
        
        public string GameName
        {
            get { return this.gameName; }
        }

        public string IconSource
        {
            get { return this.iconSource; }
        }
    }
}
