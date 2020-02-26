using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace test_app.Model
{
    class ButtonProperties : Button, INotifyPropertyChanged
    {

        static int x = -1;
        
        public int NumberButton { get; set; }
        static  string[] answer;
        static bool[] buttonIsInable;
        static SolidColorBrush[] colorButton;
        static Data data;

        static public string[] Answer { get => answer; set => answer = value; }
        static public bool[] ButtonIsInable { get => buttonIsInable; set => buttonIsInable = value; }
        static public SolidColorBrush[] ColorButton { get => colorButton; set => colorButton = value; }
        static public Data Data { get => data; set => data = value; }

        public ButtonProperties()
        {
            NumberButton = x;
            x++;
        }

        public void CheckCoreectAnswer(int nuberButton)
        {
            if(Answer[nuberButton] == data.CorectAnswer)
            {

                ColorButton[nuberButton] = Brushes.Green;
                ButtonIsInable[nuberButton] = false;
            }
            else
            {
                ColorButton[nuberButton] = Brushes.Red;
                ButtonIsInable[nuberButton] = false;
            }
        }
        public void NewQuestion()
        {
            for (int i = 0; i < 5; i++)
            {
                ColorButton[i] = Brushes.LightGray;
                ButtonIsInable[i] = true;
            }
            data.NewQuestionContext(0,10);
            Answer = data.ContentButton;
        }








        #region PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        } 
        #endregion
    }
}
