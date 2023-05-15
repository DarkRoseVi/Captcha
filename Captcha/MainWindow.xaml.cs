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

namespace Captcha
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private static Random rn = new Random();
        private static int countsymbol = 6;

        private void but_Click(object sender, RoutedEventArgs e)
        {
            countsymbol = rn.Next(5, 8);
            UpdateCapcha();
        }
        public void GenereatrSymbo() 
        {
            string alp = "1234567890ABCDEFGHIJKLMNOP";
            for (int i = 0; i < countsymbol; i++)
            {
                string symbol = alp.ElementAt(rn.Next(0, alp.Length)).ToString();
                TextBlock textBox = new TextBlock();
                textBox.Text = symbol;
                textBox.FontSize = rn.Next(10, 20);
                textBox.RenderTransform = new RotateTransform(rn.Next(-45, 45));
                textBox.Margin = new Thickness(10,0,10,0);
                stac.Children.Add(textBox);
            }
        }
        //генерация 
        public void GenereateShum(int noise) 
        {
            for (int i = 0; i < noise; i++)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Fill = new SolidColorBrush(
                    Color.FromArgb(
                     (byte)rn.Next(100,256),
            (byte)rn.Next(100, 256),
                     (byte)rn.Next(100, 256),
                     (byte)rn.Next(100, 256)));
                ellipse.Height = ellipse.Width = rn.Next(20,50);
                canvas.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, rn.Next(0,300));
                Canvas.SetLeft(ellipse, rn.Next(0, 200));
            }
            for (int i = 0; i < noise; i++)
            {
                Rectangle ellipse = new Rectangle();
                ellipse.Fill = new SolidColorBrush(
                    Color.FromArgb(
                     (byte)rn.Next(100, 200),
                     (byte)rn.Next(100, 256),
                     (byte)rn.Next(100, 256),
                     (byte)rn.Next(100, 256)));
                ellipse.Height = ellipse.Width = rn.Next(20, 50);
                canvas.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, rn.Next(0, 300));
                Canvas.SetLeft(ellipse, rn.Next(0, 120));
            }
        }
        public void UpdateCapcha()
        {
            stac.Children.Clear();
            canvas.Children.Clear();
            GenereatrSymbo();
            GenereateShum(100);
        }
    }
}
