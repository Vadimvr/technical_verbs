
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Model;

namespace ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        #region Fileds
        ButtonList ContentAndcolors;
       
        string[] contentButton;
        bool buttonIsEnable = false;
        private RelayCommand newQuestionAndStartTest;
        private RelayCommand checkForTheCorrectAnswer;
        private string question;

        #endregion

        #region properties
        public bool ButtonIsEnable { get => buttonIsEnable; set { buttonIsEnable = value; OnPropertyChanged("ButtonIsEnable"); } }
        public string[] ContentButton { get => contentButton; set { contentButton = value; OnPropertyChanged("ContentButton"); } }
         public string Question { get => question; set {question = value; OnPropertyChanged("Question"); }}



#endregion

#region Commands
public RelayCommand CheckForTheCorrectAnswer
        {
            get
            {
                return checkForTheCorrectAnswer ??
                  (checkForTheCorrectAnswer = new RelayCommand(obj =>
                  {
                      if (!ContentAndcolors.ButtonStart.IsEnabled)
                      {

                          Button but = obj as Button;
                          if (but != null)
                          {
                              ContentAndcolors.AddButtonList(but);
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
                          if (ContentAndcolors == null)
                          {
                              ContentAndcolors = new ButtonList(but);
                              ButtonIsEnable = true;
                          }

                          ContentAndcolors.NewRandomQuestion();
                          Question = ContentAndcolors.Question;
                          ContentButton = ContentAndcolors.ContentButton;

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
    }
}

