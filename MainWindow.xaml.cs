﻿using System;
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
using System.IO;
using Microsoft.Win32;

namespace technical_verbs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        string answer;
        bool start = false;

        int corectAnswer = 0;
        int mistakeAnswer = 0;

        List<Button> buttons1 = new List<Button>();
        public MainWindow()
        {
            InitializeComponent();
            buttons1 = new List<Button> { butAnswer1, butAnswer2, butAnswer3, butAnswer4, butAnswer5 };
            List<TextBlock> ansverMistekeAndCorect = new List<TextBlock> { textMisteke, textСorrectAnswer };
        }





        private void butAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Name == butStart.Name)
            {
                if (!start)
                {
                    start = true;
                    butStart.Content = "Next";
                    textUserName.IsEnabled = false;
                }

                ButtonContext();
                butStart.IsEnabled = false;
                ((Button)sender).Background = Brushes.Red;

            }
            else
            {
                if (start)
                {
                    if (((Button)sender).Content.ToString() == answer)
                    {
                        ((Button)sender).Background = Brushes.Green;
                        butStart.Background = Brushes.Green;
                        butStart.IsEnabled = true;

                        corectAnswer++;

                        textСorrectAnswer.Text = corectAnswer.ToString();


                    }
                    else
                    {
                        if (!butStart.IsEnabled)

                        {
                            ((Button)sender).Background = Brushes.Red;
                            mistakeAnswer++;
                            textMisteke.Text = mistakeAnswer.ToString();
                        }
                    }
                }
            }
        }

        public void ButtonContext()
        {
            int x;
            
            int[] randoms = new int[5];
            int temp = 0;
            Random rnd = new Random();
            randoms[0] = rnd.Next(0, Data.data.Count-1);
            for (int i = 1; i < 5; i++)
            {
                temp = rnd.Next(0, Data.data.Count - 1);

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

        private void credeUser_Click(object sender, RoutedEventArgs e)
        {
            if (!start)
            {
                textUserName.IsEnabled = true;
               
            }
        }

        private void saveFile_Click(object sender, RoutedEventArgs e)
        {
            string mydocu = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\tv\";
            if (!Directory.Exists(mydocu))
                Directory.CreateDirectory(mydocu);

            mydocu += $"{textUserName.Text}.vbdata";
            StreamWriter sr = File.CreateText(mydocu);

            sr.WriteLine($"{textUserName.Text}");
            sr.WriteLine($"{corectAnswer}");
            sr.WriteLine($"{mistakeAnswer}");

            sr.Close();
            MessageBox.Show($"Profile {textUserName.Text} save");

        }

        private void openFile_Click(object sender, RoutedEventArgs e)
        {
            string filePath;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "vbdata files(*.vbdata) | *.vbdata";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\tv\";
            if (ofd.ShowDialog()== true)
            {
                filePath = ofd.FileName;
                StreamReader sr = File.OpenText(filePath);
                try
                {
                    textUserName.Text = sr.ReadLine();
                    corectAnswer = int.Parse(sr.ReadLine());
                    mistakeAnswer = int.Parse(sr.ReadLine());
                    textMisteke.Text = mistakeAnswer.ToString();
                    textСorrectAnswer.Text = corectAnswer.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Фаил поврежден");
                }

            }
            
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            saveFile_Click(sender, e);
            this.Close();
        }
    }
}



