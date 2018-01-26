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
        public GameIcon(string name)
        {
            this.name = name;
        }

        private string name;
        private string path;
        private string type;
        private ImageSource iconImage;

        public string Name { get => name; set => name = value; }
        public string Path { get => path; set => path = value; }
        public string Type { get => type; set => type = value; }
        public ImageSource IconImage { get => iconImage; set => iconImage = value; }
        
    }
}
