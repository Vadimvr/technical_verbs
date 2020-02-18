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
using System.Windows.Shapes;

namespace technical_verbs
{
    /// <summary>
    /// Логика взаимодействия для inputBox.xaml
    /// </summary>
   public interface IInputBox
    {
        string NewUserName { get; }
        void ShowIInputBox();

        void CloseIInputBox();
        event EventHandler InputBox_close;
    }
    public partial class InputBox : Window,IInputBox
    {
        public string NewUserName { get; private set; }
        public InputBox()
        {
            InitializeComponent();
        }

        public event EventHandler InputBox_close;

        private void Ok_button_Click(object sender, RoutedEventArgs e)
        {
            NewUserName = user_name.Text; 
            if(InputBox_close!=null)
                InputBox_close(this, EventArgs.Empty);

        }
        public void ShowIInputBox()
        {
            this.Show();
        }
        public void CloseIInputBox()
        {

            this.Close();
        }
    }
}
