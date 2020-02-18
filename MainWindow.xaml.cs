using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace technical_verbs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        string answer;
        bool start = false;
        bool correctAnswer;
        List<Button> buttons1 = new List<Button>();
        public MainWindow()
        {
            InitializeComponent();
            buttons1 = new List<Button> { butAnswer1, butAnswer2, butAnswer3, butAnswer4, butAnswer5};
        }
        
        

   

        private void butAnswer_Click(object sender, RoutedEventArgs e)
        {
            if(((Button)sender).Name == butStart.Name )
            {
                if (!start)
                {
                    start = true;
                    butStart.Content = "Next";
                }

                ButtonContext();
                butStart.IsEnabled = false;
                ((Button)sender).Background = Brushes.Red;
               
            }
            else
            {
                if (((Button)sender).Content == answer && start)
                {
                    ((Button)sender).Background = Brushes.Green;
                    butStart.Background = Brushes.Green;
                    butStart.IsEnabled = true;
                    
                }
                else
                    if(!butStart.IsEnabled && start)
                        ((Button)sender).Background = Brushes.Red;
            }

        }

        public void ButtonContext()
        {
            int x;

            int[] randoms = new int[5];
            int temp = 0;
            Random rnd = new Random();
            randoms[0] = rnd.Next(0, 10);
            for (int i = 1; i < 5; i++)
            {
                temp = rnd.Next(0, 5);

                for (int j = 0; j <= i; j++)
                {
                    if (j == i)
                    {
                        randoms[i] = temp;

                    }
                    else if (randoms[j] == temp)
                    {
                        i--; break;
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                buttons1[i].Content = Data.data[randoms[i]][0];
                buttons1[i].Background = Brushes.LightGray;

            }
            x = randoms[rnd.Next(0, 4)];
           
            answer = Data.data[x][0];
            textRus.Text = Data.data[x][1];

        }
    }

}

