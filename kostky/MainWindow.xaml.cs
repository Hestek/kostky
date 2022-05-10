using System;
using System.Collections.Generic;
using System.IO;
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
            ZobrazKostku(k1, kostky[0].Hodnota);
            ZobrazKostku(k2, kostky[1].Hodnota);
            ZobrazKostku(k3, kostky[2].Hodnota);
            ZobrazKostku(k4, kostky[3].Hodnota);
            ZobrazKostku(k5, kostky[4].Hodnota);
            ZobrazKostku(k6, kostky[5].Hodnota);
        }



        public MainWindow()
        {
            InitializeComponent();
            ZobrazKostky();

        }

        private ImageSource GetImage(byte[] resource)
        {
            MemoryStream memoryStream = new MemoryStream(resource);
            BitmapFrame bitmapFrame = BitmapFrame.Create(memoryStream);
            Image image = new Image();
            image.Source = bitmapFrame;
            return image.Source;
        }

        private void ZobrazKostku(Rectangle rectangle, int cislo)
        {
            if (cislo == 1)
            {
                rectangle.Fill = new ImageBrush(GetImage(Properties.Resources.dice_1));
            }
            else if (cislo == 2)
            {
                rectangle.Fill = new ImageBrush(GetImage(Properties.Resources.dice_2));
            }
            else if (cislo == 3)
            {
                rectangle.Fill = new ImageBrush(GetImage(Properties.Resources.dice_3));
            }
            else if (cislo == 4)
            {
                rectangle.Fill = new ImageBrush(GetImage(Properties.Resources.dice_4));
            }
            else if (cislo == 5)
            {
                rectangle.Fill = new ImageBrush(GetImage(Properties.Resources.dice_5));
            }
            else if (cislo == 6)
            {
                rectangle.Fill = new ImageBrush(GetImage(Properties.Resources.dice_6));
            }

        }

        private void HodKostky_Click(object sender, RoutedEventArgs e)
        {
            foreach (var kostka in kostky)
            {
                kostka.Hod();
            }
            ZobrazKostky();
            SpocitejBody();
            lblBody.Content = $"Body: {SpocitejBody()}";
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
                pocty[kostka.Hodnota]++;
            }
            if (pocty.ContainsValue(6))
            {
                var kostka = pocty.First(hodnota => hodnota.Value == 6).Key;
                if (kostka == 1)
                {
                    body = 8000;
                }
                else
                {
                    body = kostka * 800;
                }
            }
            else if (pocty.ContainsValue(5))
            {
                var kostka = pocty.First(hodnota => hodnota.Value == 5).Key;
                if (kostka == 1)
                {
                    body = 4000;
                    body += 50 + pocty[5];
                }
                else
                {
                    body = kostka * 400;
                    body += 100 + pocty[1];
                    body += 50 + pocty[5];

                }
            }
            else if (pocty.ContainsValue(4))
            {
                var kostka = pocty.First(hodnota => hodnota.Value == 5).Key;
                if (kostka == 1)
                {
                    body = 2000;
                    body += 50 + pocty[5];
                }
                else
                {
                    body = kostka * 200;
                    body += 100 + pocty[1];
                    body += 50 + pocty[5];

                }

                
            }
            else if (pocty.ContainsValue(3))
            {
                var kostka = pocty.First(hodnota => hodnota.Value == 5).Key;
                if (kostka == 1)
                {
                    body = 1000;
                    
                }
                else
                {
                    body = kostka * 100;
                }
                int PocetTrojic = 0;
                foreach(var pocet in pocty)
                {
                    if(pocet.Value == 3)
                    {
                        PocetTrojic++;
                    }
                }

            }

            return body;
        }
    }
}
