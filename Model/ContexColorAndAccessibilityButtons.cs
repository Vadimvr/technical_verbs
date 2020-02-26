using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace test_app.Model
{
    public class ContexColorAndAccessibilityButtons : INotifyPropertyChanged
    {

        public static bool CorrektAnswer { get; set; }
        public static string Answer = "first";
        private string context;
        private SolidColorBrush buttonColor;
        private bool buttonIsEnable;
        private static int mistake;
        private static int correct;
        private bool buttonStartIsEnable = false;
        public static string Question { get; set; }
        public int Mistake
        {
            get => mistake; set
            {

                mistake = value;
                OnPropertyChanged("Mistake");
            }
        }
        public int Correct { get => correct; set { correct = value; OnPropertyChanged("Correct"); } }
        public bool ButtonStartIsEnable
        {
            get => buttonStartIsEnable; set { buttonStartIsEnable = value; OnPropertyChanged("ButtonStartIsEnable"); }
        }

        public string Context { get => context; set { context = value; OnPropertyChanged("Context"); } }
        public SolidColorBrush ButtonColor { get => buttonColor; set { buttonColor = value; OnPropertyChanged("ButtonColor"); } }
        public bool ButtonIsEnable
        {
            get => buttonIsEnable; set { buttonIsEnable = value; OnPropertyChanged("ButtonIsEnable"); }
        }
        public ContexColorAndAccessibilityButtons()
        {
            Context = "";
            ButtonColor = Brushes.LightGray;
            ButtonIsEnable = true;
        }
        public ContexColorAndAccessibilityButtons(string contex, bool isEnable, SolidColorBrush color)
        {
            Context = contex;
            ButtonColor = color;
            ButtonIsEnable = isEnable;
        }
        #region PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
        /// <summary>
        /// default color text and accessibility buttons 
        /// </summary>
        public void Default()
        {
            Context = "";
            ButtonColor = Brushes.LightGray;
            ButtonIsEnable = true;
        }
    }
}
