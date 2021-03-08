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

    public partial class Window2 : Window
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
        public Window2()
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
            Window2 window2 = this;
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            window2.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            GotCorrect = false;
            if (namelist.Count == 0)
            {
                namelist.Add(Albania);
                namelist.Add(Andorra);
                namelist.Add(Austria);
                namelist.Add(Belarus);
                namelist.Add(Belgium);
                namelist.Add(Bosnia_and_Herzegovina);
                namelist.Add(Bulgaria);
                namelist.Add(Croatia);
                namelist.Add(Czech_Republic);
                namelist.Add(Denmark);
                namelist.Add(Estonia);
                namelist.Add(Faroe_Islands);
                namelist.Add(Finland);
                namelist.Add(France);
                namelist.Add(Germany);
                namelist.Add(Gibraltar);
                namelist.Add(Greece);
                namelist.Add(Hungary);
                namelist.Add(Iceland);
                namelist.Add(Ireland);
                namelist.Add(Isle_of_Man);
                namelist.Add(Italy);
                namelist.Add(Latvia);
                namelist.Add(Liechtenstein);
                namelist.Add(Lithuania);
                namelist.Add(Luxembourg);
                namelist.Add(Macedonia);
                namelist.Add(Malta);
                namelist.Add(Moldova);
                namelist.Add(Monaco);
                namelist.Add(Montenegro);
                namelist.Add(Netherlands);
                namelist.Add(Norway);
                namelist.Add(Poland);
                namelist.Add(Portugal);
                namelist.Add(Romania);
                namelist.Add(Russia);
                namelist.Add(San_Marino);
                namelist.Add(Serbia);
                namelist.Add(Slovakia);
                namelist.Add(Slovenia);
                namelist.Add(Spain);
                namelist.Add(Sweden);
                namelist.Add(Switzerland);
                namelist.Add(Ukraine);
                namelist.Add(United_Kingdom);


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
