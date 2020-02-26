using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;



namespace ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region Fileds
        private ContexColorAndAccessibilityButtons buttonStart = new ContexColorAndAccessibilityButtons("Start", true, Brushes.LightGray);
        private string question = "Click Start";
        private int numberOfCorrectAnswers;
        private int numberOfIncorrectAnswersr;
        public QuestionsAndAnswerOptions data = new QuestionsAndAnswerOptions();
        private List<ContexColorAndAccessibilityButtons> listWithParametersByDisplayingTheButtons = new List<ContexColorAndAccessibilityButtons> {
        new ContexColorAndAccessibilityButtons ("", false, Brushes.LightGray),
        new ContexColorAndAccessibilityButtons ("", false, Brushes.LightGray),
        new ContexColorAndAccessibilityButtons ("", false, Brushes.LightGray),
        new ContexColorAndAccessibilityButtons ("", false, Brushes.LightGray),
        new ContexColorAndAccessibilityButtons ("", false, Brushes.LightGray),
        };

        private RelayCommand newQuestionAndStartTest;
        private RelayCommand checkForTheCorrectAnswer;
        #endregion

        #region properties 
        public ContexColorAndAccessibilityButtons ButtonStart { get => buttonStart; set { buttonStart = value; OnPropertyChanged("ButtonStart"); } }
        public string Question { get => question; set { question = value; OnPropertyChanged("Question"); } }
        public int NumberOfCorrectAnswers { get => numberOfCorrectAnswers; set { numberOfCorrectAnswers = value; OnPropertyChanged("NumberOfCorrectAnswers"); } }
        public int NumberOfIncorrectAnswersr { get => numberOfIncorrectAnswersr; set { numberOfIncorrectAnswersr = value; OnPropertyChanged("NumberOfIncorrectAnswersr"); } }

        public List<ContexColorAndAccessibilityButtons> ListWithParametersByDisplayingTheButtons { get => listWithParametersByDisplayingTheButtons; set { listWithParametersByDisplayingTheButtons = value; OnPropertyChanged("ListWithParametersByDisplayingTheButtons"); } }
        #endregion

        #region Commands
        public RelayCommand CheckForTheCorrectAnswer
        {
            get
            {
                return checkForTheCorrectAnswer ??
                  (checkForTheCorrectAnswer = new RelayCommand(obj =>
                  {
                      ButtonProperties but = obj as ButtonProperties;
                      if (ContexColorAndAccessibilityButtons.CorrektAnswer)
                          Question = "Please click Next.";
                      if (but != null && !ContexColorAndAccessibilityButtons.CorrektAnswer)
                      {
                          if (but != null && but.Content.ToString() == ContexColorAndAccessibilityButtons.Answer)
                          {
                              if (but.Background == Brushes.LightGray)
                                  buttonStart.Correct++;
                                  //NumberOfCorrectAnswers++;
                              ListWithParametersByDisplayingTheButtons[but.NumberButton].ButtonColor = Brushes.Green;
                              ContexColorAndAccessibilityButtons.CorrektAnswer = true;
                              ButtonStart.ButtonIsEnable = !false;

                          }
                          else
                          {
                              if (but.Background == Brushes.LightGray)
                                  buttonStart.Mistake++;
                              // NumberOfIncorrectAnswersr++;

                              ListWithParametersByDisplayingTheButtons[but.NumberButton].ButtonColor = Brushes.Red;
                          }
                      }

                  }));
            }
        }
        public RelayCommand NewQuestionAndStartTest
        {
            get
            {
                return newQuestionAndStartTest ??
                  (newQuestionAndStartTest = new RelayCommand(obj =>
                  {
                      Button but = obj as Button;
                      if (but != null)
                      {
                          SettingButtonontext(data);
                          ContexColorAndAccessibilityButtons.CorrektAnswer = false;
                          ButtonStart.ButtonIsEnable = false;
                          ButtonStart.ButtonColor = Brushes.Green;
                          ButtonStart.Context = "Next";
                      }
                  }));
            }
        }
        #endregion

        #region PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion

        #region method for setting the text in buttons 

        void SettingButtonontext(QuestionsAndAnswerOptions _data)
        {
            _data.NewQuestionContext(0, _data.LenghtList);
            ContexColorAndAccessibilityButtons.Answer = _data.CorectAnswer;
            Question = _data.Question;
            for (int i = 0; i < 5; i++)
            {
                ListWithParametersByDisplayingTheButtons[i].Default();
                ListWithParametersByDisplayingTheButtons[i].Context = _data.ContentButton[i];
            }
        }
        #endregion
    }
}
