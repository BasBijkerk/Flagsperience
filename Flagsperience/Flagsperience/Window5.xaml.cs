using System;
using System.Collections.Generic;
using System.Windows.Threading;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;






namespace Flagsperience
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>

    public partial class Window5 : Window
    {



        public List<Image> namelist = new List<Image>();
        public Random roll = new Random();
        public bool CreateList = false;

        public Image CorrectImg;

        public int elapsedtimes = 0;

        public bool marker;
        public int markercount = 0;

        public bool GotCorrect = false;

        public bool elapsed = false;
        public bool flip = false;
        public Window5()
        {
            InitializeComponent();


            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(250);
            timer.Tick += timerTick;
            timer.Start();
           
        }


        private void timerTick(Object sender, EventArgs e)
        {
            //elapsedtimes++;
            //WinLose.Content = elapsedtimes.ToString();
            /*
            if (marker)
            {
                if(markercount == 0)
                {
                    Marker.Opacity = 1;
                }
                if (markercount == 1)
                {
                    Marker.Opacity = 0.6;
                }
                if (markercount == 2)
                {
                    Marker.Opacity = 1;
                }
                if (markercount == 3)
                {
                    Marker.Opacity = 0.6;
                }
                if (markercount == 4)
                {
                    Marker.Opacity = 1;
                }
                if (markercount == 5)
                {
                    Marker.Opacity = 0.6;
                }
                if (markercount == 6)
                {
                    Marker.Opacity = 0;
                    markercount = 0;
                    marker = false;
                }
                markercount++;
                
            }
            */
            if(elapsed == true && CorrectImg != null)
            {
                //CorrectImg.Margin =
                button1.IsEnabled = false;
                //label1.Content = elapsedtimes;
                if(elapsedtimes <= 9 && !flip)
                {
                    
                    CorrectImg.Opacity = 1.0;
                }
                if(elapsedtimes <= 9 && flip)
                {
                    
                    CorrectImg.Opacity = 0;
                }
                flip = !flip;
                elapsedtimes++;
                if (elapsedtimes >= 10)
                {
                    elapsedtimes = 0;
                    elapsed = false;
                    CorrectImg.Opacity = 1;
                    button1.IsEnabled = true;
                }

            }
            
            
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Window5 window5 = this;
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            window5.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            GotCorrect = false;
            if (namelist.Count == 0)
            {
                namelist.Add(American_Samoa);
                namelist.Add(Australia);
                namelist.Add(Cook_Islands);
                namelist.Add(Fiji);
                namelist.Add(French_Polynesia);
                namelist.Add(Guam);
                namelist.Add(Kiribati);
                namelist.Add(Marshall_Islands);
                namelist.Add(Micronesia);
                namelist.Add(Nauru);
                namelist.Add(New_Caledonia);
                namelist.Add(New_Zealand);
                namelist.Add(Niue);
                namelist.Add(Northern_Mariana_Islands);
                namelist.Add(Palau);
                namelist.Add(Papua_New_Guinea);
                namelist.Add(Samoa);
                namelist.Add(Solomon_Islands);
                namelist.Add(Tokelau);
                namelist.Add(Tonga);
                namelist.Add(Tuvalu);
                namelist.Add(Vanuatu);
                namelist.Add(Wallis_and_Futuna);
                


                CreateList = !CreateList;
                SetRandom();
            }
            else
            {
                SetRandom();
            }
            
        }
        private void SetRandom()
        {
            CorrectImg = namelist[roll.Next(namelist.Count - 1)];
            label1.Content = CorrectImg.ToolTip;
            WinLose.Content = "";
        }
        
        private void Click1(Object sender, MouseButtonEventArgs e)
        {
            if (sender is Image image)
            {
                /*

                Marker.RenderTransform = image.RenderTransform;
                if (Marker.RenderTransform == image.RenderTransform)
                {
                    marker = true;
                }
                */
                if (CorrectImg.Name == image.Name && GotCorrect == false)
                {
                    if(Score.Content.ToString() != "")
                    {
                        Score.Content = float.Parse(Score.Content.ToString()) + 1;
                        GotCorrect = true;
                    }
                    if(Score.Content.ToString() == "")
                    {
                        
                        Score.Content = "1";
                        GotCorrect = true;
                    }
                    //SetRandom();
                    WinLose.Content = "Correct!";
                    WinLose.Foreground = Brushes.DarkGreen;
                    
                }
                if(CorrectImg.Name != image.Name)
                {
                    Score.Content = 0;
                    WinLose.Content = "Wrong!";
                    WinLose.Foreground = Brushes.IndianRed;


                    elapsed = true;
                    
                }
            }
            
        }
        public void BlinkImage()
        {

            elapsed = true;
            
        }
        public void ReturnOpacity()
        {
            CorrectImg.Opacity = 1.0;
        }
    }
}
