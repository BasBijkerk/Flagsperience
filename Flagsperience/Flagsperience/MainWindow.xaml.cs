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

namespace Flagsperience
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
            MainWindow mainwindow = this;
            mainwindow.Close();
        }
        private void button_Click2(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3();
            window3.Show();
            MainWindow mainwindow = this;
            mainwindow.Close();
        }
        private void button_Click3(object sender, RoutedEventArgs e)
        {
            Window4 window4 = new Window4();
            window4.Show();
            MainWindow mainwindow = this;
            mainwindow.Close();
        }
        private void button_Click4(object sender, RoutedEventArgs e)
        {
            Window5 window5 = new Window5();
            window5.Show();
            MainWindow mainwindow = this;
            mainwindow.Close();
        }

        private void button_Click5(object sender, RoutedEventArgs e)
        {
            Window6 window6 = new Window6();
            window6.Show();
            MainWindow mainwindow = this;
            mainwindow.Close();
        }

        private void button_Click6(object sender, RoutedEventArgs e)
        {
            Window7 window7 = new Window7();
            window7.Show();
            MainWindow mainwindow = this;
            mainwindow.Close();
        }

        private void buttonHelp(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            MainWindow mainwindow = this;
            mainwindow.Close();
        }
    }
}
