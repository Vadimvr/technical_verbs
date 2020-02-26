//using Model;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Controls;
//using System.Windows.Media;

//namespace ViewModel
//{
//    public class ViewModel : INotifyPropertyChanged
//    {

//        private string[] contentButton = new string[5];
//        Data data = new Data();
//        bool start = true;
//        bool vin = false;
//        bool defaulButoon;
//        private RelayCommand checkForTheCorrectAnswer;
//        private RelayCommand newQuestion;
//        private string question = "Click start";
//        private int corectAnswer;
//        private int mistakes;
//        private SolidColorBrush colorButoonCorectAnswer = Brushes.Green;
//        private SolidColorBrush colorButoonNotCorectAnswer = Brushes.Red;
//        private SolidColorBrush colorButoonDefault = Brushes.LightGray;
//        public bool DefaulButoon { get => defaulButoon; set { defaulButoon = value; OnPropertyChanged("DefaulButoon"); } }
//        public string Answer { get; set; }
//        public string[] ContentButton
//        {
//            get => contentButton;
//            set
//            {
//                contentButton = value;
//                Question = data.Question;
//                Answer = data.CorectAnswer;
//                OnPropertyChanged("ContentButton");
//            }
//        }

//        public bool Start { get => start; set { start = value; OnPropertyChanged("Start"); } }
//        public Data ContentData { get => data; set { data = value; OnPropertyChanged("Data"); } }

//        public bool Vin { get => vin; set { vin = value; OnPropertyChanged("Vin"); } }
//        public int CorectAnswer { get => corectAnswer; set { corectAnswer = value; OnPropertyChanged("CorectAnswer"); } }
//        public int Mistakes { get => mistakes; set { mistakes = value; OnPropertyChanged("Mistakes"); } }
//        public string Question { get => question; set { question = value; OnPropertyChanged("Question"); } }
//        public SolidColorBrush ColorButoonCorectAnswer { get => colorButoonCorectAnswer; set => colorButoonCorectAnswer = value; }
//        public SolidColorBrush ColorButoonNotCorectAnswer { get => colorButoonNotCorectAnswer; set => colorButoonNotCorectAnswer = value; }
//        public SolidColorBrush ColorButoonDefault { get => colorButoonDefault; set { colorButoonDefault = value; } }



//        public RelayCommand CheckForTheCorrectAnswer
//        {
//            get
//            {
//                return checkForTheCorrectAnswer ??
//                  (checkForTheCorrectAnswer = new RelayCommand(obj =>
//                  {
//                      Button but = obj as Button;
//                      if (but != null)
//                      {
//                          if (but.Content.ToString() == Answer)
//                          {
//                              but.Foreground = ColorButoonCorectAnswer;
//                              Vin = !Vin;

//                              Start = !Start;
//                              CorectAnswer++;
//                          }
//                          else
//                          {
//                              Mistakes++;

//                              but.Foreground = ColorButoonNotCorectAnswer;
//                              but.IsEnabled = false;
//                          }
//                      }
//                  }));
//            }

//        }



//        public RelayCommand NewQuestion
//        {
//            get
//            {
//                return newQuestion ??
//                  (newQuestion = new RelayCommand(obj =>
//                  {
//                      Button but = obj as Button;

//                      if (but != null)
//                      {
                          
//                          but.Content = "Next";
//                          Vin = true;
//                          Start = false;
//                          DefaulButoon = true;
//                          ContentButton = data.NewQuestionContext(0, 10);
//                      }
//                  }));


//            }
//        }


//        public event PropertyChangedEventHandler PropertyChanged;
//        public void OnPropertyChanged([CallerMemberName]string prop = "")
//        {
//            if (PropertyChanged != null)
//                PropertyChanged(this, new PropertyChangedEventArgs(prop));
//        }

//    }
//}
