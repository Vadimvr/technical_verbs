using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ViewModel
{
    public class ViewModel
    {
        

        private RelayCommand checkForTheCorrectAnswer;
        public RelayCommand CheckForTheCorrectAnswer
        {
            get
            {
                return checkForTheCorrectAnswer ??
                  (checkForTheCorrectAnswer = new RelayCommand(obj =>
                  {
                      Button but = obj as Button;
                      if (but != null && but.Name == "o1")
                      {
                          but.Content = "new name";
                      }
                  }));
            }

        }
        private RelayCommand newQuestion;
        public RelayCommand NewQuestion
        {
            get
            {
                return newQuestion ??
                  (newQuestion = new RelayCommand(obj =>
                  {
                      Button but = obj as Button;
                      if (but != null && but.Name == "o1")
                      {
                          but.Content = "new name";
                      }
                  }));


            }
        }
    }
}
