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

    public partial class Window4 : Window
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
        public Window4()
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
            if (elapsed == true && CorrectImg != null)
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
            Window4 window4 = this;
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            window4.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            GotCorrect = false;
            if (namelist.Count == 0)
            {
                namelist.Add(Argentina);
                namelist.Add(Bolivia);
                namelist.Add(Brazil);
                namelist.Add(Chile);
                namelist.Add(Colombia);
                namelist.Add(Ecuador);
                namelist.Add(Falkland_Islands);
                namelist.Add(Guyana);
                namelist.Add(Paraguay);
                namelist.Add(Peru);
                namelist.Add(Suriname);
                namelist.Add(Uruguay);
                namelist.Add(Venezuela);
                namelist.Add(French_Guiana);


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
