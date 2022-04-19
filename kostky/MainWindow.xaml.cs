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

namespace kostky
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //kostka[] kostky = new kostka[6];
        kostka[] kostky = new kostka[] {
            new kostka(),
            new kostka(),
            new kostka(),
            new kostka(),
            new kostka(),
            new kostka(),
        };

        private void ZobrazKostky()
        {
            kostka0.Content = kostky[0].Hodnota;
            kostka1.Content = kostky[1].Hodnota;
            kostka2.Content = kostky[2].Hodnota;
            kostka3.Content = kostky[3].Hodnota;
            kostka4.Content = kostky[4].Hodnota;
            kostka5.Content = kostky[5].Hodnota;
        }


          
            



        public MainWindow()
        {
            InitializeComponent();
            ZobrazKostky();
        }

        private void HodKostky_Click(object sender, RoutedEventArgs e)
        {
            foreach(var kostka in kostky)
            {
                kostka.Hod();
            }
            ZobrazKostky();
        }

        private int SpocitejBody()
        {
            int body = 0;
            Dictionary<int, int> pocty = new Dictionary<int, int>();
            pocty.Add(1, 0);
            pocty.Add(2, 0);
            pocty.Add(3, 0);
            pocty.Add(4, 0);
            pocty.Add(5, 0);
            pocty.Add(6, 0);

            foreach (var kostka in kostky)
            {
                if (kostka.Hodnota == 1)
                {
                    pocty[kostka.Hodnota]++;
                }
                
                
            }
            return body;
        }


    }
}
