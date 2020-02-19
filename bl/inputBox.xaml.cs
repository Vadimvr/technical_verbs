using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace technical_verbs
{
    /// <summary>
    /// Логика взаимодействия для inputBox.xaml
    /// </summary>
    public interface IInputBox
    {
        int Last_index{ get; }
        int Start_index{ get; }
        string NewUserName { get; }
        void ShowIInputBox();

        void CloseIInputBox();
        event EventHandler InputBox_close;
    }
    public partial class InputBox : Window, IInputBox
    {
        int last_index_int;
        int start_index_int;
        int list_count ;
        public int List_count { get { return list_count; } set { list_count = value; } }
        public int Start_index
        {
            get{return start_index_int;}
            set
            {
               if(start_index_int > -1 && value !=-1)
                {
                    if (value < Last_index - 4)
                        start_index_int = value;
                    if(value >= Last_index - 4 && Last_index< List_count)
                    {
                        Last_index++;
                        start_index_int = value;
                    }
                }
            }
        }
        public int Last_index
        {
            get {return last_index_int; }
            set
            {
                if (last_index_int < list_count + 1 && value <= list_count )
                {
                    if (value > Start_index + 4)
                        last_index_int = value;
                    if (value <= Start_index + 4 && Start_index > 0)
                    {
                        Start_index--;
                        last_index_int = value;
                    }
                }
            }
        }
        #region MyRegion

        public string NewUserName { get; private set; }
        public InputBox(int i)
        {
            List_count = i;
            Last_index = i;
            
            InitializeComponent();
        }

        public event EventHandler InputBox_close;

        private void Ok_button_Click(object sender, RoutedEventArgs e)
        {
            NewUserName = user_name.Text;
            if (start_index.Text.DefaultIfEmpty().All(char.IsDigit))
                if (int.Parse(start_index.Text) >= 0 && int.Parse(start_index.Text) <= List_count - 5)
                {
                    Start_index = int.Parse(start_index.Text);
                    start_index.Background = Brushes.Green;
                }
                else
                {
                    start_index.Background = Brushes.Red;
                    start_index.Text = $"ведите число от 0 до {List_count - 5}";
                }
            else if (!start_index.Text.DefaultIfEmpty().All(char.IsDigit))
            {
                start_index.Text = $"ведите число от 0 до {List_count - 5}";
            }
            else
            {
                start_index.Text = $"ведите число от 0 до {List_count - 5}";
            }

            if (InputBox_close != null)
                InputBox_close(this, EventArgs.Empty);

        }
        public void ShowIInputBox()
        {
            start_index.Text = Start_index.ToString();
            last_index.Text = Last_index.ToString();
            this.Show();
        }
        public void CloseIInputBox()
        {

            this.Close();
        }
        #endregion

        private void Index_Click(object sender, RoutedEventArgs e)
        {


            if (((RepeatButton)sender).Content.ToString() == "<")
            {
                if (((RepeatButton)sender).Name == "plus_start_index")
                {
                    Start_index--;
                    
                }
                else
                {
                    Last_index--;
                    
                }
            }
            else
            {
                if (((RepeatButton)sender).Name == "minus_start_index")
                {
                    Start_index++;
                    
                }
                else
                {
                    Last_index++;
                    
                }
            }
            start_index.Text = Start_index.ToString();
            last_index.Text = Last_index.ToString();
        }
        
    }
}
  
